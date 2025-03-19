using System.Collections;
using TMPro;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    public static SkillSystem instance;
    public static TextMeshProUGUI skillName1;
    public static TextMeshProUGUI skillName2;
    private static bool IsSkill1Available = true;
    private static bool IsSkill2Available = true;

    public void Awake()
    {
        instance = this;
        skillName1 = GameObject.Find("Text (TMP) SK1").GetComponent<TextMeshProUGUI>();
        skillName2 = GameObject.Find("Text (TMP) SK2").GetComponent<TextMeshProUGUI>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
                StartSkill2CountDown(30, skillName2);
            }
        }
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