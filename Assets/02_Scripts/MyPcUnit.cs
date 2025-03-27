using UnityEngine;
using UnityEngine.Serialization;

public class MyPcUnit : MonoBehaviour
{
    public UnitData CurrentUnitData { get; set; }
    public Animator unitAnimator;
    
    public void InitUnit(int MaxHp, int CurrentHp, float Speed, float RotationSpeed, bool IsAlive , int UnitID)
    {
        CurrentUnitData = new UnitData
        {
            MaxHp = MaxHp,
            CurrentHp = CurrentHp,
            Speed = Speed,
            RotationSpeed = RotationSpeed,
            IsAlive = true,
            UnitID = UnitID
        };
    }

    public void OnHit(int damage)
    {
        if (CurrentUnitData != null)
        {
            return;
        }
    }

    public void OnDeath()
    {
        if  (CurrentUnitData != null)
            return;
    }

    private void Start()
    {
        
    }
    
    private void Update()
    {
        
    }
}