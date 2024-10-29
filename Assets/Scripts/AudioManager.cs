using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _this;

    private static AudioSource currentlyPlaying;

    // Start is called before the first frame update
    void Start()
    {
        if (_this == null)
        {
            _this = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void ChangeCurrentlyPlaying(AudioSource audio)
    {
        currentlyPlaying = audio;
        currentlyPlaying.Play();
        MenuController.GetThis().ChangeMusicName();
    }

    public static void AdjustVolume(float volume)
    {
        if (currentlyPlaying != null)
            currentlyPlaying.volume = volume;
    }

    public static void PlayCurrentTrack()
    {
        if (currentlyPlaying != null)
            currentlyPlaying.Play();
    }

    public static void PauseCurrentlyPlaying()
    {
        if (currentlyPlaying != null)
            currentlyPlaying.Pause();
    }

    public static void StopCurrentlyPlaying()
    {
        if (currentlyPlaying != null)
            currentlyPlaying.Stop();
        currentlyPlaying = null;
        MenuController.GetThis().ChangeMusicName();
    }

    public static AudioSource GetCurrentlyPlaying()
    {
        return currentlyPlaying;
    }
}
