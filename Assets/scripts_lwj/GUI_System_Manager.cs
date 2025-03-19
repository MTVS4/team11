using TMPro;
using UnityEngine;

public class GUI_System_Manager : MonoBehaviour
{
    public static GUI_System_Manager Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
