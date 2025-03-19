using UnityEngine;

public class GameSystem_Manager : MonoBehaviour
{
    public static GameSystem_Manager Instance;
    private Canvas thirdCanvas;
    public int SceneNumber = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameSystem_Manager.Instance.SceneNumber == 3) 
        {
            thirdCanvas = GameObject.Find("Third_Canvas").GetComponent<Canvas>();
            thirdCanvas.enabled = true; 
            Debug.Log($"SceneNumber : {GameSystem_Manager.Instance.SceneNumber}");
        }
    }
}
