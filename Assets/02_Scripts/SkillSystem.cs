using System.Collections;
using TMPro;
using UnityEngine;
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
    public static int currentCharacterID;
    
    public void Awake()
    {
        Instance = this;
    }

    void Start()
    {
    }

    void Update()
    {
        Debug.Log($"캐릭터 ID: {GameManager.Instance.UnitID}"); //오류남 지워야함
        Debug.Log($"캐릭터 ID: {currentCharacterID}");
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Input.GetKeyDown(KeyCode.Q) : Q is Pressed");
            
            if (IsSkill1Available == true)
            {
                StartSkill1CountDown(15, skillName1);
            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Input.GetKeyDown(KeyCode.E) : E is Pressed");
            
            if (IsSkill2Available == true)
            {
                if (currentCharacterID == 1)
                {
                    Debug.Log("(GameManager.Instance.UnitID == GameManager.CharacterID.Sage)");
                    SageSkill2();
                }
                else if (currentCharacterID == 2)
                {
                    Debug.Log("(GameManager.Instance.UnitID == GameManager.CharacterID.Jett)");
                    JettSkill2();
                }
                StartSkill2CountDown(30, skillName2);

            }
        }
    }

    private void SageSkill2()
    {
        myPcUnitData.CurrentHp += 10;
        currentHPText.text = myPcUnitData.CurrentHp.ToString();
    }

    private void JettSkill2()
    {
        PlayerController.Instance.MoveSpeed = 8f;
        PlayerController.Instance.JumpForce = 1000f;
        Invoke("ResetCharacterStatus", 5f);
    }

    private void ResetCharacterStatus()
    {
        PlayerController.Instance.MoveSpeed = 4f;
        PlayerController.Instance.JumpForce = 500f;
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