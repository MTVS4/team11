using UnityEngine;

public class FirstCanv : MonoBehaviour
{
    public static FirstCanv Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("INPUT is detacted -> disable&destroy fisrtcanv");
            Canvas firstCanvas = GameObject.Find("First_Canvas").GetComponent<Canvas>();
            firstCanvas.enabled = false;
            var gameSystemManager = GameObject.Find("GameSystem_Manager").GetComponent<GameSystem_Manager>();
            gameSystemManager.SceneNumber = 3;
            Destroy(GameObject.Find("First_Canvas"));
        }
    }
}
