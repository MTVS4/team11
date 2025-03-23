using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager
{
    private static SpawnManager _instance;
    public static SpawnManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SpawnManager();
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
