using UnityEngine;

public class UnitData
{
    public int MaxHp { get; set; } = 0;
    public int CurrentHp { get; set; } = 0;
    public float Speed { get; set; } = 0f;
    public float RotationSpeed { get; set; } = 0f;
    public bool IsAlive { get; set; }
    public int UnitID { get; set; }
}
