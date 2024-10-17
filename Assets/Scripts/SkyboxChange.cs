using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChange : MonoBehaviour
{
    [SerializeField]
    private Material skybox;

    public void ChangeSkybox(Texture2D panorama)
    {
        skybox.SetTexture("_MainTex", panorama);
    }
}
