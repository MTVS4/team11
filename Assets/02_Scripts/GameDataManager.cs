using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager
{
    public int Round {get; private set;}
    private GameObject MyPlayer;
    private Transform SpawnRoot;
    private Transform SkillRoot;
    private Transform ItemRoot;
    
    private static GameDataManager _instance;
    public static GameDataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameDataManager();
            }
            return _instance;
        }
    }
    public void Init()
    {
    }
    public void Clear()
    {
        Round = 0;
        MyPlayer = null;
        SpawnRoot = null;
        SkillRoot = null;
        ItemRoot = null;
    }
    public void SetCurrentRound(int roundNumber)
    {
        Round = roundNumber;
    }
    public void SetRoundData(GameObject Player, Transform SpawnPoint, Transform SkillPoint, Transform ItemPoint)
    {
        MyPlayer = Player;
        SpawnRoot = SpawnPoint;
        SkillRoot = SkillPoint;
        ItemRoot = ItemPoint;
    }

    public GameObject GetPlayer()
    {
        return MyPlayer;
    }

    public Transform GetSpawnPoint()
    {
        return SpawnRoot;
    }

    public Transform GetSkillPoint()
    {
        return SkillRoot;
    }

    public Transform GetItemPoint()
    {
        return ItemRoot;
    }
}
