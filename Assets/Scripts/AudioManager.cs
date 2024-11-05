using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _this;

    private static AudioSource currentlyPlaying;
    private static float globalVolume;

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
        globalVolume = 1f;
    }

    /// <summary>
    /// Cette méthode change la musique qui se joue pour la source en paramètre.
    /// </summary>
    /// <param name="audio">La nouvelle source de musique.</param>
    public static void ChangeCurrentlyPlaying(AudioSource audio)
    {
        currentlyPlaying = audio;
        currentlyPlaying.volume = globalVolume;
        currentlyPlaying.Play();
        MenuController.GetThis().ChangeMusicName();
    }

    /// <summary>
    /// Cette méthode ajuste le volume des musiques qui sont et vont être jouées.
    /// </summary>
    /// <param name="volume">Le volume entre 0 et 1 des sources audio passant par l'audio manager.</param>
    public static void AdjustVolume(float volume)
    {
        if (currentlyPlaying != null)
            currentlyPlaying.volume = volume;
        globalVolume = volume;
    }

    /// <summary>
    /// Cette méthode démarre ou relance l'audio courant.
    /// </summary>
    public static void PlayCurrentTrack()
    {
        if (currentlyPlaying != null)
            currentlyPlaying.Play();
    }

    /// <summary>
    /// Cette méthode pause l'audio courant.
    /// </summary>
    public static void PauseCurrentlyPlaying()
    {
        if (currentlyPlaying != null)
            currentlyPlaying.Pause();
    }

    /// <summary>
    /// Cette méthode arrête l'audio courant et le retire du stockage.
    /// </summary>
    public static void StopCurrentlyPlaying()
    {
        if (currentlyPlaying != null)
            currentlyPlaying.Stop();
        currentlyPlaying = null;
        MenuController.GetThis().ChangeMusicName();
    }
    
    /// <summary>
    /// Cette fonction retourne la source audio stockée.
    /// </summary>
    /// <returns>La source audio stockée, qu'elle soit en train de jouer ou non.</returns>
    public static AudioSource GetCurrentlyPlaying()
    {
        return currentlyPlaying;
    }

    /// <summary>
    /// Cette fonction retourne le volume global actuel de l'audio.
    /// </summary>
    /// <returns>La valeur entre 0 et 1 du volume global actuel.</returns>
    public static float GetGlobalVolume()
    {
        return globalVolume;
    }
}
