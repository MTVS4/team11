using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    //싱글톤 전역 변수
    public static GameManager Instance { get; set; }
    
    public GameObject player1;
    public int StageID { get; set;} = 1;
    
    public Transform PlayerSpawnPoint { get; set; }
    public Transform NpcSpawnParent { get; set; }
    public Transform SkillObjectParent { get; set; }
    public Transform ItemObjectParent { get; set; }
    private PCSetting _myPCSetting;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // 어떤 씬으로 넘어가던 본 객체가 절대 부서지지 마시오.
        Instance = this;
        SceneManager.LoadSceneAsync("Lobby Scene", LoadSceneMode.Additive);
    }
    
    private void Start()
    {
        SpawnManager.Instance.Init();
        FSMStateController.Instance.Init();
        GameDataManager.Instance.Init();
        GameDataManager.Instance.SetRoundData(player1, PlayerSpawnPoint, SkillObjectParent, ItemObjectParent);
    }

    private void OnDestroy()
    {
        SpawnManager.Instance.Clear();
        FSMStateController.Instance.Clear();
        GameDataManager.Instance.Clear();
    }

    public void SetFSMstateToProgress()
    {
        FSMStateController.Instance.SetFSMCurrentState(EFSMStateType.Progress);
        FSMStateController.Instance.StartGame();
    }
    
    public void SetFSMstateToWin()
    {
        FSMStateController.Instance.SetFSMCurrentState(EFSMStateType.Win);
        FSMStateController.Instance.StartGame();
    }
    
    private void Update()
    {
    }
}
