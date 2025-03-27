using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl
{
    private static GameControl _instance;
    public static GameControl Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameControl();
            }
            return _instance;
        }
    }
    public GameObject ControlObject;

    public void OnUpdate()
    {
        
    }

    private void UpdateKeyboardInput()
    {
        
    }
    public void Init()
    {
    }
    public void Clear()
    {
    }
}
