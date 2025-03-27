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
        SceneManager.UnloadSceneAsync("UI Scene");
        SceneManager.LoadScene("Shotting Scene",LoadSceneMode.Additive);
    }

}
