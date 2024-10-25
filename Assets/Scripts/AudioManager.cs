using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _this;

    private AudioSource currentlyPlaying;

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

    public void ChangeCurrentlyPlaying(AudioSource audio)
    {
        currentlyPlaying = audio;
        currentlyPlaying.Play();
    }

    public void AdjustVolume(float volume)
    {
        currentlyPlaying.volume = volume;
    }

    public void PlayCurrentTrack()
    {
        currentlyPlaying.Play();
    }

    public void PauseCurrentlyPlaying()
    {
        currentlyPlaying.Pause();
    }

    public void StopCurrentlyPlaying()
    {
        currentlyPlaying.Stop();
        currentlyPlaying = null;
    }

    public AudioSource GetCurrentlyPlaying()
    {
        return currentlyPlaying;
    }
}
