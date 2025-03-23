using UnityEngine;

public class MyPcUnit : MonoBehaviour
{
    public UnitData CurrentUnitData;
    public Animator UnitAnimator;
    
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
