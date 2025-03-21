using System;
using Unity.Mathematics;
using UnityEngine;

public class GunControll : MonoBehaviour
{
    public GameObject bullet;
    public Vector3 gunholeposition;
    public Camera maincam;
    void Awake()
    {
        gunholeposition = GameObject.Find("gunhole").transform.position;
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
        GameObject newBullet = Instantiate(bullet, gunholeposition, quaternion.identity);
        var bulletRigidbody = newBullet.GetComponent<Rigidbody>();
        Vector3 screancenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = maincam.ScreenPointToRay(screancenter);
        bulletRigidbody.AddForce(ray.direction, ForceMode.Impulse);
    }
}
