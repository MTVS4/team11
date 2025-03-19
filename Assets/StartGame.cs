using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject scence;
    public GameObject player1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Loadnextscene()
    {
        SceneManager.LoadScene("shotting");
        //Destroy(GameObject.Find("LobbyCanvas"));
        //Instantiate(scence);
        //Instantiate(player1);
        //Destroy(GameObject.Find("backgroundimage"));
    }
}
