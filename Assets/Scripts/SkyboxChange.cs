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

    public void ChangeSkybox(Texture2D panorama)
    {
        skybox.SetTexture("_MainTex", panorama);
        videoPlayer.Stop();
    }

    public void ChangeSkybox(VideoClip videoClip)
    {
        skybox.SetTexture("_MainTex", videoPlayer.targetTexture);
        videoPlayer.clip = videoClip;
        videoPlayer.Play();
    }
}
