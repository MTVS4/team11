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
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }

    private void SetPC()
    {
        Application.targetFrameRate = _myPCSetting.FixedFrameRate;
    }
    private void Start()
    {
        GamePoolManager.Instance.Init();
        GameControl.Instance.Init();
        SpawnManager.Instance.Init();
        FSMStateController.Instance.Init();
        GameDataManager.Instance.Init();
        GameDataManager.Instance.SetCurrentRound(StageID);
        GameDataManager.Instance.SetRoundData(player1, PlayerSpawnPoint, SkillObjectParent, ItemObjectParent);
    }

    private void OnDestroy()
    {
        GamePoolManager.Instance.Clear();
        GameControl.Instance.Clear();
        SpawnManager.Instance.Clear();
        FSMStateController.Instance.Clear();
        GameDataManager.Instance.Clear();
    }

    public void SetFSMstateToProgress()
    {
        FSMStateController.Instance.SetFSMCurrentState(EFSMStateType.Progress);
        FSMStateController.Instance.StartGame();
    }
    
    private void Update()
    {
        GameControl.Instance.OnUpdate();
    }
}
