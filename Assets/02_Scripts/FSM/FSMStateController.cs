using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FSMStateController
{
    public static FSMStateController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new FSMStateController();
            }
            return _instance;
        }
    }
    private static FSMStateController _instance;
    
    private EFSMStateType FSMCurrentState{get; set;}
    
    public void Init()
    {
    }
    
    public void Clear()
    {
    }
    
    public void SetFSMCurrentState(EFSMStateType newState)
    {
        if (FSMCurrentState == newState) 
            return;
        FSMCurrentState = newState;
    }
    
    public void StartGame()
    {
        // 두 줄의 순서 바꾸니 캐릭터 선택이 다음씬으로 넘어갔음.
        SceneManager.UnloadSceneAsync("Lobby Scene");
        SceneManager.LoadScene("Shooting Scene",LoadSceneMode.Additive);
    }

}
