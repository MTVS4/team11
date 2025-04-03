using System;
using System.Collections;
using UnityEngine;

public class DroneControl : MonoBehaviour
{
    public bool isDemaged;
    private int droneCurrentHP;
    private int playerNewCurrentHp;
    private int originalCurrentHP;
    private int droneAttackPower = 3;
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
        droneCurrentHP = 100;
    }

    public void TakeDamage(int damage)
    {
        droneCurrentHP -= damage;
        Debug.Log($"currentHP : {droneCurrentHP}");
        damagedEffect.Play();
        damagedAudioSource.Play();
        if (droneCurrentHP > 0)
        {
            DroneAttack();
            Invoke("StopDroneAttack", 5f);
        }
        else
        {
            if (ShootingUIManager.Instance.WinorLoseState != ShootingUIManager.WinorLose.lose)
            {
                ShootingUIManager.Instance.WinorLoseState = ShootingUIManager.WinorLose.win;
                ShootingUIManager.Instance.ShowWinPanel();
                StopAllCoroutines();
            }
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
        playerNewCurrentHp = HP;
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(i);
            playerNewCurrentHp -= droneAttackPower;
            SkillSystem.Instance.myPcUnitData.CurrentHp = playerNewCurrentHp;
            SkillSystem.Instance.currentHPText.text = SkillSystem.Instance.myPcUnitData.CurrentHp.ToString();
            if (playerNewCurrentHp <= 0)
            {
                Debug.Log("Player die");
                SkillSystem.Instance.currentHPText.text = "DIE";
                if (ShootingUIManager.Instance.WinorLoseState != ShootingUIManager.WinorLose.win)
                {
                    ShootingUIManager.Instance.WinorLoseState = ShootingUIManager.WinorLose.lose;
                    ShootingUIManager.Instance.ShowLosePanel();
                    StopAllCoroutines();
                    break;
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void StopDroneAttack()
    {
        droneAttackEffect.Stop();
    }


    void Update()
    { 
        /*
        if (currentHP <= 0)
        {
            if (ShootingUIManager.Instance.WinorLoseState == ShootingUIManager.WinorLose.win)
                return;
            droneAttackEffect.gameObject.SetActive(false);
            StopCoroutine("HPDownCoroutine");
            Destroy(currentDrone);
            deadAudioSource.Play();
            ShootingUIManager.Instance.WinorLoseState = ShootingUIManager.WinorLose.win;
            ShootingUIManager.Instance.ShowWinPanel();
        }*/
    }
}
