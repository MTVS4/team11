using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SkillSystem : MonoBehaviour
{
    public static SkillSystem Instance;
    public TextMeshProUGUI currentHPText;
    public TextMeshProUGUI skillName1;
    public TextMeshProUGUI skillName2;
    private bool IsSkill1Available = true;
    private bool IsSkill2Available = true;
    public MyPcUnitData myPcUnitData = new MyPcUnitData();
    [SerializeField] private GameObject jettSkill2;
    [SerializeField] private GameObject sageSkill2;
    public GameObject effectVolume;
    private GameObject newEffectVolume;
    private Camera _maincam;
    private Vector3 _screancenter;
    private Vector3 _crossHairPosition;
    private Scene targetScene;
    public GameObject swordPrefab;

    public void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _maincam = Camera.main;
        targetScene = SceneManager.GetSceneByName("Shooting Scene");
    }

    void Update()
    {
        if (myPcUnitData.CurrentHp <= 0)
            ShootingUIManager.Instance.ShowLosePanel();
        
        Debug.Log($"캐릭터 ID: {GameManager.UnitID}");
        if (jettSkill2.active)
        {
            jettSkill2.transform.position = _maincam.transform.position;
        }

        if (sageSkill2.active)
        {
            sageSkill2.transform.position = _maincam.transform.position;
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Input.GetKeyDown(KeyCode.Q) : Q is Pressed");
            
            if (IsSkill1Available == true)
            {                
                if (GameManager.UnitID == GameManager.CharacterID.Sage)
                {
                    Debug.Log("(GameManager.Instance.UnitID == GameManager.CharacterID.Sage)");
                    SageSkill1();
                }
                else if (GameManager.UnitID == GameManager.CharacterID.Jett)
                {
                    Debug.Log("(GameManager.Instance.UnitID == GameManager.CharacterID.Jett)");
                    JettSkill1();
                }
                StartSkill1CountDown(15, skillName1);
            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Input.GetKeyDown(KeyCode.E) : E is Pressed");
            
            if (IsSkill2Available == true)
            {
                if (GameManager.UnitID == GameManager.CharacterID.Sage)
                {
                    Debug.Log("(GameManager.Instance.UnitID == GameManager.CharacterID.Sage)");
                    SageSkill2();
                }
                else if (GameManager.UnitID == GameManager.CharacterID.Jett)
                {
                    Debug.Log("(GameManager.Instance.UnitID == GameManager.CharacterID.Jett)");
                    JettSkill2();
                }
                StartSkill2CountDown(30, skillName2);

            }
        }
    }
    
    private void SageSkill1()
    {
        _crossHairPosition = GameObject.Find("CrossHair").transform.position;
        _screancenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray screenCenterToRay = _maincam.ScreenPointToRay(_screancenter);
        if (Physics.Raycast(screenCenterToRay, out RaycastHit hit, 100f,LayerMask.GetMask("Ground", "Wall")))
        {
            newEffectVolume = Instantiate(effectVolume, hit.point, Quaternion.identity);
            SceneManager.MoveGameObjectToScene(newEffectVolume, targetScene);
            Invoke("FadeOutAndDestroyEffectVolume", 5f);
        }
    }

    private void FadeOutAndDestroyEffectVolume()
    {

        StartCoroutine("FadeOutEffectVolume");
    }
    private void JettSkill1()
    {
        _crossHairPosition = GameObject.Find("CrossHair").transform.position;
        _screancenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray screenCenterToRay = _maincam.ScreenPointToRay(_screancenter);
        float swordSpeed = 50f;
        GameObject newSwordPrefab = Instantiate(swordPrefab, _crossHairPosition, Quaternion.identity);
        SceneManager.MoveGameObjectToScene(newSwordPrefab, targetScene);
        var newSwordPrefabRigidbody = newSwordPrefab.GetComponent<Rigidbody>();
        
        newSwordPrefabRigidbody.AddForce(screenCenterToRay.direction * swordSpeed, ForceMode.Impulse);

        if (Physics.Raycast(screenCenterToRay, out RaycastHit hit, swordSpeed, LayerMask.GetMask("Enemy")))
        {
            
            Destroy(hit.transform.gameObject);
            ShootingUIManager.Instance.ShowWinPanel();
        }
    }

    private void SageSkill2()
    {
        sageSkill2.SetActive(true);
        myPcUnitData.CurrentHp += 5;
        currentHPText.text = myPcUnitData.CurrentHp.ToString();
        Invoke("EndSageSkill2Effect", 5f);
    }

    private void EndSageSkill2Effect()
    {
        myPcUnitData.CurrentHp += 5;
        currentHPText.text = myPcUnitData.CurrentHp.ToString();
        sageSkill2.SetActive(false);
    }

    private void JettSkill2()
    {
        PlayerControl.Instance.MoveSpeed = 8f;
        PlayerControl.Instance.JumpForce = 1000f;
        jettSkill2.SetActive(true);
        Invoke("ResetCharacterStatus", 5f);
    }

    private void ResetCharacterStatus()
    {
        PlayerControl.Instance.MoveSpeed = 4f;
        PlayerControl.Instance.JumpForce = 500f;
        jettSkill2.SetActive(false);
    }

    public void StartSkill1CountDown(float seconds, TextMeshProUGUI skill)
    {
        StartCoroutine(Skill1CountDownCoroutine(seconds, skill));
    }
    public void StartSkill2CountDown(float seconds, TextMeshProUGUI skill)
    {
        StartCoroutine(Skill2CountDownCoroutine(seconds, skill));
    }
    public IEnumerator Skill1CountDownCoroutine(float totalSeconds, TextMeshProUGUI sk)
    {
        IsSkill1Available = false;
        string originalskill1Name = sk.text;
        for (int i = 0; i <= totalSeconds; i++)
        {
            Debug.Log($"Skill1CountDownCoroutine : {i}");
            float value = totalSeconds - i;
            sk.text = value.ToString();
            if (value == 0)
            {
                sk.text = originalskill1Name;
                IsSkill1Available = true;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public IEnumerator FadeOutEffectVolume()
    {
        float originalVolumeWeight = newEffectVolume.GetComponent<Volume>().weight;
        for (float i = originalVolumeWeight; i >= 0; i -= Time.deltaTime)
        {
            if (i < 0.1f)
            {
                Destroy(newEffectVolume);
                Debug.Log("destroy effectVolume");
                yield break;
            }
            Debug.Log($"FadeOutEffectVolume : {i}");
            newEffectVolume.GetComponent<Volume>().weight = i;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
    public IEnumerator Skill2CountDownCoroutine(float totalSeconds, TextMeshProUGUI sk2)
    {
        IsSkill2Available = false;
        string originalskill2Name = sk2.text;
        for (int i = 0; i <= totalSeconds; i++)
        {
            Debug.Log($"Skill2CountDownCoroutine : {i}");
            float value = totalSeconds - i;
            sk2.text = value.ToString();
            if (value == 0)
            {
                sk2.text = originalskill2Name;
                IsSkill2Available = true;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}