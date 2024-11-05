using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRRayInteractor))]
public class RemoteAction : MonoBehaviour
{
    private XRRayInteractor rayInteractor;

    // Start is called before the first frame update
    void Start()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        rayInteractor.uiPressInput.manualPerformed = false; // Configure le statut par défaut du Ray Interactor.
        rayInteractor.uiPressInput.manualValue = 1f;
    }

    /// <summary>
    /// Cette méthode permet d'activer les interactions UI avec le Ray Interactor de la télécommande. Est conçue pour aller dans la liste d'événement Activated du composant Grab Interactable.
    /// </summary>
    public void Activate()
    {
        rayInteractor.uiPressInput.manualPerformed = true;
    }

    /// <summary>
    /// Cette méthode permet de désactiver les interactions UI avec le Ray Interactor de la télécommande. Est conçue pour aller dans la liste d'événement Deactivated du composant Grab Interactable.
    /// </summary>
    public void Deactivate()
    {
        rayInteractor.uiPressInput.manualPerformed = false;
    }
}
