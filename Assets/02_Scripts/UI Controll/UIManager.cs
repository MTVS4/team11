using UnityEngine;

public class UIManager : MonoBehaviour
{
    //싱글톤 전역 변수
    public static UIManager Instance { get; set; }
    
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
        Invoke("RestartGame", 5f);
    }

    public void RestartGame()
    {   
        var BGMManager = GameObject.Find("BGMManager");
        Destroy(BGMManager);
        GameManager.Instance.RestartGame();
    }
    public void ShowLosePanel()
    {
        Debug.Log("Lose");
        losePanel.SetActive(true);
        FSMStateController.Instance.SetFSMCurrentState(EFSMStateType.Win);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
