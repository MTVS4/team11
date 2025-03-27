using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class GunControll : MonoBehaviour
{
    private int speed = 100;
    private Vector3 _screancenter;
    public float bullletdistance = 1000f;
    public GameObject bullet;
    public Vector3 crossHairPosition;
    private Camera _maincam;

    private void Awake()
    {
        _maincam = Camera.main;
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        
    }

    private void Fire()
    {
        crossHairPosition = GameObject.Find("CrossHair").transform.position;
        _screancenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray screenCenterToRay = _maincam.ScreenPointToRay(_screancenter);
        
        GameObject newBullet = Instantiate(bullet, crossHairPosition, quaternion.identity);
        var bulletRigidbody = newBullet.GetComponent<Rigidbody>();
        
        bulletRigidbody.AddForce(screenCenterToRay.direction * speed, ForceMode.Impulse);

        if (Physics.Raycast(screenCenterToRay, out RaycastHit hit, bullletdistance, LayerMask.GetMask("Enemy")))
        {
            Destroy(hit.transform.gameObject);
        }
    }
    
}