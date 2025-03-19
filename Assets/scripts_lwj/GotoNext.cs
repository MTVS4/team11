using UnityEngine;

public class GotoNext : MonoBehaviour
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

    public void NextScene()
    {
        Instantiate(scence);
        Instantiate(player1);
        Destroy(this.gameObject);
    }
}
