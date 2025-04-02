using System;
using System.Collections;
using UnityEngine;

public class DroneControl : MonoBehaviour
{
    public bool isDemaged;
    private int currentHP;
    private int newCurrentHP;
    private int originalCurrentHP;
    [SerializeField] GameObject crosshair;
    [SerializeField] GameObject currentDrone;
    [SerializeField] ParticleSystem damagedEffect;
    [SerializeField] AudioSource deadAudioSource;
    [SerializeField] AudioSource damagedAudioSource;
    [SerializeField] ParticleSystem droneAttackEffect;
    [SerializeField] private GameObject droneAttackTarget;
    private void Awake()
    {
        isDemaged = false;
        currentHP = 100;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log($"currentHP : {currentHP}");
        damagedEffect.Play();
        damagedAudioSource.Play();
        if (currentHP >= 0)
        {
            DroneAttack();
            Invoke("StopDroneAttack", 5f);
        }
    }

    private void DroneAttack()
    {
        droneAttackEffect.Play();
        originalCurrentHP = SkillSystem.Instance.myPcUnitData.CurrentHp;
        StartCoroutine(HPDownCoroutine(originalCurrentHP));
        
    }
    IEnumerator HPDownCoroutine(int HP)
    {
        newCurrentHP = HP;
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(i);
            newCurrentHP -= 5;
            SkillSystem.Instance.myPcUnitData.CurrentHp = newCurrentHP;
            SkillSystem.Instance.currentHPText.text = SkillSystem.Instance.myPcUnitData.CurrentHp.ToString();
            yield return new WaitForSeconds(1f);
        }
        yield break;
    }

    private void StopDroneAttack()
    {
        droneAttackEffect.Stop();
    }


    void Update()
    { 
        
        if (currentHP <= 0)
        {
            droneAttackEffect.gameObject.SetActive(false);
            Destroy(currentDrone);
            deadAudioSource.Play();
            ShootingUIManager.Instance.ShowWinPanel();
            
        }
    }
}
