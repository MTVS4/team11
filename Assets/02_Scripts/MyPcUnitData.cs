using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class MyPcUnitData
{
    public enum CharacterID
    {
        Sage = 1,
        Jett = 2,
    }
    public int MaxHp = 100;
    public int CurrentHp = 100;
    public float MoveSpeed = 4f;
    public float JumpForce = 500f;
}