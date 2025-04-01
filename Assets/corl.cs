using UnityEngine;

public class corl :MonoBehaviour
{
    public void RandomColor()
    {
        var renderer = GetComponent<Renderer>();
        renderer.material.color = Random.ColorHSV();
    }
}
