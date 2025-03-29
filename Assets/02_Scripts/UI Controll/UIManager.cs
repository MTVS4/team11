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
    }
    public void ShowLosePanel()
    {
        Debug.Log("Lose");
        losePanel.SetActive(true);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
