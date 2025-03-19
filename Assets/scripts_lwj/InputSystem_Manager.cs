using UnityEngine;

public class InputSystem_Manager : MonoBehaviour
{
    public static InputSystem_Manager Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
        Debug.Log("Input System Manager : Initialized");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Input.GetKeyDown(KeyCode.Q) : Q is Pressed");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Input.GetKeyDown(KeyCode.W) : W is Pressed");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Input.GetKeyDown(KeyCode.E) : E is Pressed");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Input.GetKeyDown(KeyCode.A) : A is Pressed");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Input.GetKeyDown(KeyCode.S) : S is Pressed");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Input.GetKeyDown(KeyCode.D) : D is Pressed");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Input.GetKeyDown(KeyCode.Space) : Space is Pressed");
        }
        
    }
}
