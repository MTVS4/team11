using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GunControl : MonoBehaviour
{
    public float bulletDistance = 1000f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject crossHair;
    [SerializeField] private AudioSource gunFireAudioSource;
    [SerializeField] private GameObject droneEnemy;
    [SerializeField] private GameObject attackTarget;
    [SerializeField] private ParticleSystem attackEffect;
    private Camera _maincam;
    private Vector3 _screancenter;
    private Vector3 _crossHairPosition;
    private const int BulletSpeed = 100;
    [SerializeField] private Scene targetScene;

    private void Awake()
    {
        _maincam = Camera.main;
    }
    
    

    private void Start()
    {
        targetScene = SceneManager.GetSceneByName("Shooting Scene");
    }

    private void PlayGunFireSound()
    {
        gunFireAudioSource.Play();
    }

    private void Update()
    {
        if (ShootingUIManager.Instance.WinorLoseState == ShootingUIManager.WinorLose.lose)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            PlayGunFireSound();
            Fire();
        }
    }

    private void Fire()
    {
        _crossHairPosition = GameObject.Find("CrossHair").transform.position;
        _screancenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray screenCenterToRay = _maincam.ScreenPointToRay(_screancenter);
        
        GameObject newBullet = Instantiate(bullet, _crossHairPosition, _maincam.transform.rotation);
        SceneManager.MoveGameObjectToScene(newBullet, targetScene);
        var bulletRigidbody = newBullet.GetComponent<Rigidbody>();
        
        bulletRigidbody.AddForce(screenCenterToRay.direction * BulletSpeed, ForceMode.Impulse);

        if (Physics.Raycast(screenCenterToRay, out RaycastHit hit, bulletDistance, LayerMask.GetMask("Enemy")))
        {
            droneEnemy.GetComponent<DroneControl>().TakeDamage(SkillSystem.Instance.playerGunPower);
        }
        
    }
    
}