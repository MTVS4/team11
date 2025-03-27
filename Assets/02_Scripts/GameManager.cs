using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //싱글톤 전역 변수
    public static GameManager Instance;
    
    private PCSetting _setting;
    
    public int StageID = 1;
    public GameObject MyPlayer;
    public Transform PlayerSpawnPoint;
    public Transform NPCSpawnParent;
    public Transform SkillObjectParent;
    public Transform ItemObjectParent;
    private void Awake()
    {
        Instance = this;
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }

    private void SetPC()
    {
        Application.targetFrameRate = _setting.fixedFrameRate;
    }
    private void Start()
    {
        GamePoolManager.Instance.Init();
        GameControl.Instance.Init();
        SpawnManager.Instance.Init();
        FSMStateController.Instance.Init();
        GameDataManager.Instance.Init();
        GameDataManager.Instance.SetCurrentRound(StageID);
        GameDataManager.Instance.SetRoundData(MyPlayer, PlayerSpawnPoint, SkillObjectParent, ItemObjectParent);
        //setPC();
        
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
