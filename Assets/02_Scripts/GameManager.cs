using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    //싱글톤 전역 변수
    public static GameManager Instance { get; set; }
    public MyPcUnit myPcUnit = new MyPcUnit();
    public GameObject player1;
    
    public Transform PlayerSpawnPoint { get; set; }
    public Transform NpcSpawnParent { get; set; }
    public Transform SkillObjectParent { get; set; }
    public Transform ItemObjectParent { get; set; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // 어떤 씬으로 넘어가던 본 객체가 절대 부서지지 마시오.
        Instance = this;
        SceneManager.LoadSceneAsync("Lobby Scene", LoadSceneMode.Additive);
    }
    
    private void Start()
    {
        FSMStateController.Instance.Init();
    }

    private void OnDestroy()
    {
        FSMStateController.Instance.Clear();
    }

    public void SetFSMstateToLobby()
    {
        FSMStateController.Instance.SetFSMCurrentState(EFSMStateType.Lobby);
        FSMStateController.Instance.StartGame();
    }
    
    public void SetFSMstateToWin()
    {
        FSMStateController.Instance.SetFSMCurrentState(EFSMStateType.Win);
        FSMStateController.Instance.StartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Lobby Scene");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void Update()
    {
    }
}
