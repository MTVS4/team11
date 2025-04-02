using System;
using System.Collections;
using UnityEngine;

public class DroneControl : MonoBehaviour
{
    public bool isDemaged;
    private int currentHP;
    [SerializeField] GameObject currentDrone;
    [SerializeField] ParticleSystem damagedEffect;
    [SerializeField] AudioSource deadAudioSource;
    [SerializeField] AudioSource damagedAudioSource;
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
    }
    
    void Update()
    {
        if (currentHP <= 0)
        {
            Destroy(currentDrone);
            deadAudioSource.Play();
            ShootingUIManager.Instance.ShowWinPanel();
            
        }
    }
}
