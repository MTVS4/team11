using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    //public static CountDown Instance;
    public TextMeshProUGUI roundTimeText;
    [SerializeField] private GameObject defeatPanel;
    //public ShootingUIManager shootingUIManager;

    /*private void Awake()
    {
        Instance = this;
    }*/
    public void Start()
    {
        startCountDown(40f);
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
                if (ShootingUIManager.Instance.WinorLoseState != ShootingUIManager.WinorLose.win)
                {
                    ShootingUIManager.Instance.WinorLoseState = ShootingUIManager.WinorLose.lose;
                    ShootingUIManager.Instance.ShowLosePanel();
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
