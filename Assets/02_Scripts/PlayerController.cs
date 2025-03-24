using System.Net;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public bool ismoved;
    public bool isShootting = false;
    public Animator shooter;
    public float power = 1f;
    public float yAngle = 0f;
    private CharacterController bodyCharacterController;
    public GameObject body;
    private Vector3 _lastPoint;
    private float moveSpeed = 4f;
    private Rigidbody myRigidbody;
    
    private void Awake()
    {
        bodyCharacterController = GetComponentInChildren<CharacterController>();
        myRigidbody = GetComponent<Rigidbody>();
        body = GameObject.Find("body");
        
    }

    private void Jump()
    {
        float jumpForce = 3f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Input.GetKeyDown(KeyCode.Space) : Space is Pressed");
            var up = Vector3.up;
            myRigidbody.AddForce(up * jumpForce, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        //var dir = new Vector3(h, 0f, v).normalized;
        
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
            shooter.SetBool("IsMoved",ismoved);
        }
        else
        {
            ismoved = true;
            shooter.SetBool("IsMoved",ismoved);
        }

        if (!ismoved)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isShootting = true;
                shooter.SetBool("IsShootted", isShootting);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isShootting = false;
                shooter.SetBool("IsShootted", isShootting);
            }
        }
        var rotation = body.transform.rotation;
        rotation.y = Camera.main.transform.rotation.y;
        body.transform.rotation = rotation;
        
        //var forwardDirection = Vector3.ProjectOnPlane(body.transform.forward, Vector3.up);

        if (Input.GetKey(KeyCode.W))
        {
            body.transform.position += moveSpeed * Time.deltaTime * body.transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            body.transform.position -= moveSpeed * Time.deltaTime * body.transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            body.transform.position -= moveSpeed * Time.deltaTime * body.transform.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            body.transform.position += moveSpeed * Time.deltaTime * body.transform.right;  
        }
        
        Jump();

    }
}