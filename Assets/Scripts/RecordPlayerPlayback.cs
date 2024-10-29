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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CDInserted(SelectEnterEventArgs args)
    {
        XRBaseInteractable grabbedCD = (XRBaseInteractable)args.interactableObject;
        AudioManager.ChangeCurrentlyPlaying(grabbedCD.GetComponent<AudioSource>());
    }

    public void CDEjected(SelectExitEventArgs args)
    {
        AudioManager.StopCurrentlyPlaying();
    }
}
