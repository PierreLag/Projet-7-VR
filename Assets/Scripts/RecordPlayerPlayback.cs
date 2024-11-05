using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class RecordPlayerPlayback : MonoBehaviour
{
    [SerializeField]
    private XRSocketInteractor cdSocket;

    /// <summary>
    /// Cette m�thode permet, quand int�gr�e dans le lecteur d'�v�nement Select Entered du Socket, de lire le CD qui est ins�r� dans le lecteur de vinyl.
    /// </summary>
    /// <param name="args">Les propri�t�s du vinyl qui entre dans le socket (doit avoir une source audio).</param>
    public void CDInserted(SelectEnterEventArgs args)
    {
        XRBaseInteractable grabbedCD = (XRBaseInteractable)args.interactableObject;
        AudioManager.ChangeCurrentlyPlaying(grabbedCD.GetComponent<AudioSource>());
    }

    /// <summary>
    /// Cette m�thode permet, quand int�gr�e dans le lecteur d'�v�nement Select Exited du Socket, de retirer la lecture du vinyl de l'audio manager.
    /// </summary>
    /// <param name="args">Les propri�t�s du vinyl qui sorte du socket.</param>
    public void CDEjected(SelectExitEventArgs args)
    {
        AudioManager.StopCurrentlyPlaying();
    }
}
