using UnityEngine;

public class GameManager : MonoBehaviour
{
    //싱글톤 전역 변수
    public static GameManager Instance;

    public int StageID = 1;
    public GameObject MyPlayer;
    public Transform PlayerSpawnPoint;
    public Transform NPCSpawnParent;
    public Transform SkillObjectParent;
    public Transform ItemObjectParent;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GamePoolManager.Instance.Init();
        GameControl.Instance.Init();
        SpawnManager.Instance.Init();
        FSMStateController.Instance.Init();
        GameDataManager.Instance.Init();
        GameDataManager.Instance.SetCurrentRound(StageID);
        GameDataManager.Instance.SetRoundData(MyPlayer, PlayerSpawnPoint, SkillObjectParent, ItemObjectParent);
    }

    void OnDestroy()
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
    
    void Update()
    {
        GameControl.Instance.OnUpdate();
    }
}
