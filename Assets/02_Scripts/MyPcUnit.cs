using UnityEngine;
using UnityEngine.Serialization;

public class MyPcUnit : MonoBehaviour
{
    public UnitData CurrentUnitData;
    public Animator unitAnimator;
    
    public void InitUnit(int MaxHp, int CurrentHp, float Speed, float RotationSpeed, bool IsAlive , int UnitID)
    {
        CurrentUnitData = new UnitData();
        CurrentUnitData.MaxHp = MaxHp;
        CurrentUnitData.CurrentHp = CurrentHp;
        CurrentUnitData.Speed = Speed;
        CurrentUnitData.RotationSpeed = RotationSpeed;
        CurrentUnitData.IsAlive = true;
        CurrentUnitData.UnitID = UnitID;
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