using System.Collections;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI roundTimeText;
    void Start()
    {
        roundTimeText = GameObject.Find("CountdownText").GetComponent<TextMeshProUGUI>();
        startCountDown(40);
    }
    public void startCountDown(float seconds)
    {
        StartCoroutine(CountDownCoroutine(seconds));
    }

    IEnumerator CountDownCoroutine(float totalSeconds)
    {
        for (int i = 0; i <= totalSeconds; i++)
        {
            Debug.Log(i);
            float value = totalSeconds - i;
            roundTimeText.text = value.ToString();
            if (value == 0)
            {
                roundTimeText.text = "Time Over";
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
