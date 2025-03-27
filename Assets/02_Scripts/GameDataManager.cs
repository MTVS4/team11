using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager
{
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
    private static GameDataManager _instance;
    
    public int Round { get; private set; }
    private GameObject _myPlayer;
    private Transform _spawnRoot;
    private Transform _skillRoot;
    private Transform _itemRoot;
    
    public void Init()
    {
    }
    public void Clear()
    {
        Round = 0;
        _myPlayer = null;
        _spawnRoot = null;
        _skillRoot = null;
        _itemRoot = null;
    }
    public void SetCurrentRound(int roundNumber)
    {
        Round = roundNumber;
    }
    public void SetRoundData(GameObject Player, Transform SpawnPoint, Transform SkillPoint, Transform ItemPoint)
    {
        _myPlayer = Player;
        _spawnRoot = SpawnPoint;
        _skillRoot = SkillPoint;
        _itemRoot = ItemPoint;
    }

    public GameObject GetPlayer()
    {
        return _myPlayer;
    }

    public Transform GetSpawnPoint()
    {
        return _spawnRoot;
    }

    public Transform GetSkillPoint()
    {
        return _skillRoot;
    }

    public Transform GetItemPoint()
    {
        return _itemRoot;
    }
}
