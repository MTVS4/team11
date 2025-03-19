using UnityEngine;
using UnityEngine.SceneManagement;

public class first_to_lobby : MonoBehaviour
{
    first_to_lobby instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        instance = this;
    }
    public void Loadnextscene()
    {
        SceneManager.LoadScene("Lobby_scene");
    }
    public void Selfdestruct()
    {
        Destroy(instance.gameObject);
    }
}
