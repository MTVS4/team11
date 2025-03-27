using System.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public bool ismoved;
    public bool isShootting = false;
    
    [SerializeField] private Animator shooter;
    [SerializeField] private GameObject playerBody;
    
    private const float MoveSpeed = 4f;
    private const float JumpForce = 30f;
    private CharacterController bodyCharacterController;
    private Vector3 _lastPoint;
    private Rigidbody myRigidbody;
    private bool isGrounded;

    private void Awake()
    {
        bodyCharacterController = GetComponentInChildren<CharacterController>();
        myRigidbody = GetComponent<Rigidbody>();
        playerBody = GameObject.Find("body");
        
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Input.GetKeyDown(KeyCode.Space) : Space is Pressed");
            myRigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Collision with ground");
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Collision with wall");
            // 벽과 접촉 중일 때 damping을 무한대로 설정
            myRigidbody.linearDamping = float.PositiveInfinity;
            myRigidbody.angularDamping = float.PositiveInfinity;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Collision Wall Exit");
            // 벽에서 떨어지면 damping을 원래 값으로 복원
            myRigidbody.linearDamping = 1f;  // 기본값이나 원하는 값으로 설정
            myRigidbody.angularDamping = 0.5f;  // 기본값이나 원하는 값으로 설정   
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Collision Ground Exit");
            isGrounded = false;
        }
    }
    private void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        //var dir = new Vector3(h, 0f, v).normalized;
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
        var rotation = playerBody.transform.rotation;
        rotation.y = Camera.main.transform.rotation.y;
        playerBody.transform.rotation = rotation;
        
        //var forwardDirection = Vector3.ProjectOnPlane(body.transform.forward, Vector3.up);

        if (Input.GetKey(KeyCode.W))
        {
            playerBody.transform.position += MoveSpeed * Time.deltaTime * playerBody.transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerBody.transform.position -= MoveSpeed * Time.deltaTime * playerBody.transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerBody.transform.position -= MoveSpeed * Time.deltaTime * playerBody.transform.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerBody.transform.position += MoveSpeed * Time.deltaTime * playerBody.transform.right;  
        }
        
        Jump();
        
        

    }
}