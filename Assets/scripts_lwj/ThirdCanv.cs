using System.Collections;
using TMPro;
using UnityEngine;

public class ThirdCanv : MonoBehaviour
{
    public static ThirdCanv Instance;
    private Canvas thirdCanvas;
    private int currentTime;

    public TextMeshProUGUI roundTimeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        Instance = this;
        thirdCanvas =GetComponent<Canvas>();
        thirdCanvas.enabled = false;
        roundTimeText = GameObject.Find("CountdownText").GetComponent<TextMeshProUGUI>();
        currentTime = int.Parse(roundTimeText.text);
    }
    public void Start()
    {
        StartCoroutine(Step(40));

    }
    
    // Update is called once per frame
    public void Update()
    {
        
        if (thirdCanvas.enabled)
        {
            //Reducetime();
            //StartCoroutine(Step(40));
        }
    }

    IEnumerator Step(int count)
    {
        for (int i = count; i > 0; i--)
        {
            Debug.Log($"Step : {i}");
            roundTimeText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
    }
}
