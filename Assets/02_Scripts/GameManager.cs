using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    //싱글톤 전역 변수
    public static GameManager Instance;
    public MyPcUnitData myPcUnit = new MyPcUnitData();
    public GameObject player1;
    public Transform PlayerSpawnPoint { get; set; }
    public Transform NpcSpawnParent { get; set; }
    public Transform SkillObjectParent { get; set; }
    public Transform ItemObjectParent { get; set; }
    public CharacterID UnitID;
    public enum CharacterID
    {
        Sage = 1,
        Jett = 2,
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // 어떤 씬으로 넘어가던 본 객체가 절대 부서지지 마시오.
        Instance = this;
        SceneManager.LoadSceneAsync("Lobby Scene", LoadSceneMode.Additive);
    }
    
    private void Start()
    {
        FSMStateController.Instance.Init();
        myPcUnit = new MyPcUnitData();
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

    public void AutoRestartGame()
    {
        Invoke("RestartGame", 5f);
    }

    public void ChangeUnitIDtoJett()
    {
        if (myPcUnit == null) //필요없
        {
            myPcUnit = new MyPcUnitData();
        }
        UnitID = CharacterID.Jett;//오류남 지워야함
        SkillSystem.currentCharacterID = 2;
        Debug.Log(UnitID);
    }

    public void ChangeUnitIDtoSage()
    {
        if (myPcUnit == null)//필요없
        {
            myPcUnit = new MyPcUnitData();
        }
        UnitID = CharacterID.Sage;//오류남 지워야함
        SkillSystem.currentCharacterID = 1;
        Debug.Log(UnitID);
    }

    public void RestartGame()
    {
        var BGMManager = GameObject.Find("BGMManager");
        Destroy(BGMManager);
        SceneManager.LoadScene("Lobby Scene");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void Update()
    {
    }
}
