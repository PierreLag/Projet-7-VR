using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SkyboxChange : MonoBehaviour
{
    [SerializeField]
    private Material skybox;
    [SerializeField]
    private VideoPlayer videoPlayer;
    [SerializeField]
    private Texture2D initialSkybox;

    private void Start()
    {
        skybox.SetTexture("_MainTex", initialSkybox);
    }

    /// <summary>
    /// Cette m�thode permet de changer la skybox vers une nouvelle image de type Texture2D. Si la pr�c�dente skybox �tait une vid�o, l'arr�te.
    /// </summary>
    /// <param name="panorama">L'image Texture2D qui sera la nouvelle skybox.</param>
    public void ChangeSkybox(Texture2D panorama)
    {
        skybox.SetTexture("_MainTex", panorama);
        videoPlayer.Stop();
    }

    /// <summary>
    /// Cette m�thode permet de changer la skybox vers une nouvelle vid�o venant d'un objet VideoClip.
    /// </summary>
    /// <param name="videoClip">La vid�o qui sera la nouvelle skybox.</param>
    public void ChangeSkybox(VideoClip videoClip)
    {
        skybox.SetTexture("_MainTex", videoPlayer.targetTexture);
        videoPlayer.clip = videoClip;
        videoPlayer.Play();
    }
}
