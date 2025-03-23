using System;
using Unity.Mathematics;
using UnityEngine;

public class GunControll : MonoBehaviour
{
    public GameObject bullet;
    public Vector3 CrossHairposition;
    public Camera maincam;
    void Awake()
    {
        
        maincam = Camera.main;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fire();
        }
        
    }

    void fire()
    {
        CrossHairposition = GameObject.Find("CrossHair").transform.position;
        GameObject newBullet = Instantiate(bullet, CrossHairposition, quaternion.identity);
        var bulletRigidbody = newBullet.GetComponent<Rigidbody>();
        Vector3 screancenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = maincam.ScreenPointToRay(screancenter);
        
        bulletRigidbody.AddForce(ray.direction, ForceMode.Impulse);
    }
}
