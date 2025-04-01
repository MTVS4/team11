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
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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
