using System.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public bool ismoved;
    public Animator shooter;
    public float power = 1f;
    public float yAngle = 0f;
    private Rigidbody myrigidbody;
    public GameObject sage;
    private Vector3 _lastPoint;
    
    private void Awake()
    {
        myrigidbody = GetComponent<Rigidbody>();
        sage = GameObject.Find("Sa");
        
    }

    private void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        var dir = new Vector3(h, 0f, v).normalized;
        
        // 오른쪽 : 90 // 왼쪽 : -90
        if (Mathf.Approximately(h, 0f))
        {
        }
        else
        {
            yAngle = 90f * h;
        }
        // 1~-1 이 360 ~ 180
        // 앞 : 0
        if (v > 0f)
        {
            yAngle = 0f;
        }
        // 뒤 : 180
        if (v < 0f)
        {
            yAngle = 180f;
        }
        
        if (Mathf.Approximately(h, 0f) && Mathf.Approximately(v, 0f))
        {
            ismoved = false;
        }
        else
        {
            ismoved = true;
        }

        shooter.SetBool("IsMoved",ismoved);

        if (!ismoved)
        {
            if (Input.GetMouseButtonDown(0))
            {
                shooter.SetBool("IsShootted",true);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                shooter.SetBool("IsShootted",false);
            }
        }

        var rotation = sage.transform.rotation;
        rotation.y = Camera.main.transform.rotation.y;
        sage.transform.rotation = rotation;

        //이걸 force로 변환 할까?
        myrigidbody.position += power * Time.deltaTime * dir;
        //
        float jumpForce = 3f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Input.GetKeyDown(KeyCode.Space) : Space is Pressed");
            var up = Vector3.up;
            myrigidbody.AddForce(up * jumpForce , ForceMode.Impulse);
        }
    }
}