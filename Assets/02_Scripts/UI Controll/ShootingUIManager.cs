using TMPro;
using UnityEngine;

public class ShootingUIManager : MonoBehaviour
{
    //싱글톤 전역 변수
    public static ShootingUIManager Instance { get; set; }
    [SerializeField] private TextMeshProUGUI HPText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void ShowWinPanel()
    {
        Debug.Log("Win");
        winPanel.SetActive(true);
        GameManager.Instance.AutoRestartGame();
    }
    
    public void ShowLosePanel()
    {
        Debug.Log("Lose");
        losePanel.SetActive(true);
        FSMStateController.Instance.SetFSMCurrentState(EFSMStateType.Win);
    }
}
