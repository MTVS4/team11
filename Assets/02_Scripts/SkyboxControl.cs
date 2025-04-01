using System;
using UnityEngine;

public class SkyboxControl : MonoBehaviour
{
    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.5f);
    }
}
