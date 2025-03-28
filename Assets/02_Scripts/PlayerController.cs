using System.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public bool ismoved;
    public bool isShootting = false;
    
    [SerializeField] private Animator shooter;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerBody;
    [SerializeField] private Rigidbody myRigidbody;
    private const float MoveSpeed = 4f;
    private const float JumpForce = 10f;
    private Vector3 _lastPoint;
    public bool _isGrounded;
    public bool _isOnWall;
    public int _groundLayerMask;
    public int _wallLayerMask;

    private void Awake()
    {
        _groundLayerMask = LayerMask.GetMask("Ground");
        _wallLayerMask = LayerMask.GetMask("Wall");
        _isGrounded = true;
        _isOnWall = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Collision with ground");
            _isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Collision with wall");
            _isOnWall = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Collision Ground Exit");
            _isGrounded = false;
            Debug.Log($"_isGrounded : {_isGrounded}");
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Collision Wall Exit");
            _isOnWall = false;
            // 벽에서 떨어지면 damping을 원래 값으로 복원
            myRigidbody.linearDamping = 1f;  // 기본값이나 원하는 값으로 설정
            myRigidbody.angularDamping = 0.5f;  // 기본값이나 원하는 값으로 설정   
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
        var angles = rotation.eulerAngles;
        angles.y = Camera.main.transform.rotation.eulerAngles.y;
        rotation.eulerAngles = angles;
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
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 A = new Vector3(0, 1, 0);
            Debug.Log("Input.GetKeyDown(KeyCode.Space) : Space is Pressed");
            myRigidbody.AddForce(A * JumpForce, ForceMode.Impulse);
            Debug.Log("Input.GetKeyUp(KeyCode.Space) : Space is Released");
        }
    }
}