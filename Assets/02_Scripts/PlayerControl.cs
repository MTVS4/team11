using System;
using System.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerControl : MonoBehaviour
{
    public bool ismoved;
    public bool isShootting = false;
    public static PlayerControl Instance;
    [SerializeField] private Animator shooter;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerBody;
    [SerializeField] private Rigidbody myRigidbody;
    public float MoveSpeed;
    public float JumpForce;
    private Vector3 _lastPoint;
    public bool _isGrounded;
    public bool _isTouchingWall;
    private Vector3 _playerLastPosition;
    public int _groundLayerMask;
    public int _wallLayerMask;
    
    private void Awake()
    {
        Instance = this;
        _isGrounded = true;
    }

    private void Start()
    {
        MoveSpeed = GameManager.Instance.myPcUnit.MoveSpeed;
        JumpForce = GameManager.Instance.myPcUnit.JumpForce;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.collider.CompareTag("Wall"))
        {
            Debug.Log("Collision with Wall");
            _isTouchingWall = true;
        }
        
        if (collision.collider.CompareTag("Ground"))
        {
            Debug.Log("Collision with ground");
            _isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Debug.Log("Collision Ground Exit");
            _isGrounded = false;
            Debug.Log($"_isGrounded : {_isGrounded}");
        }
        if (collision.collider.CompareTag("Wall"))
        {
            Debug.Log("Collision with Wall");
            _isTouchingWall = false;
        }
    }
    
    private void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        _playerLastPosition = playerBody.transform.position;

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

        Debug.Log($"_isTouchingWall :  {_isTouchingWall}");
        Debug.Log($"_isGrounded : {_isGrounded}");
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            myRigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            Debug.Log("Input.GetKeyUp(KeyCode.Space) : Space is Released");
        }
    }
}