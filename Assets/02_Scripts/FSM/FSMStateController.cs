using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FSMStateController
{
    private static FSMStateController _instance;
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
    public EFSMStateType FSMCurrentState{get;private set;}
    public void SetFSMCurrentState(EFSMStateType newState)
    {
        if (FSMCurrentState == newState) 
            return;
        FSMCurrentState = newState;
    }
    public void StartGame()
    {
        SceneManager.UnloadSceneAsync("UI Scene");
        SceneManager.LoadScene("Shotting Scene",LoadSceneMode.Additive);
    }
    public void Init()
    {
    }
    public void Clear()
    {
    }
}
