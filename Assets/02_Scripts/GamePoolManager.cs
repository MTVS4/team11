using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePoolManager
{
    private static GamePoolManager _instance;
    public static GamePoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GamePoolManager();
            }
            return _instance;
        }
    }
    public void Init()
    {
    }
    public void Clear()
    {
    }
}
