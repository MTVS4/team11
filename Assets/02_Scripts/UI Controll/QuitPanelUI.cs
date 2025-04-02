using UnityEngine;

public class QuitPanelUI : MonoBehaviour
{
    public GameObject quitPanelCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DisableQuitPanel()
    {
        quitPanelCanvas.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            QuitGame();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            DisableQuitPanel();
        }
    }
}
