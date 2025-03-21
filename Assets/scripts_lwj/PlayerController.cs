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
    private Rigidbody rigidbody;

    private Vector3 _lastPoint;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        
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

        //transform.rotation = Quaternion.Euler(0f, yAngle, 0f);
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

        //이걸 force로 변환 할까?
        rigidbody.position += power * Time.deltaTime * dir;
        //
        float jumpForce = 1f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Input.GetKeyDown(KeyCode.Space) : Space is Pressed");
            var up = Vector3.up;
            rigidbody.AddForce(up * jumpForce , ForceMode.Impulse);
        }
    }
}