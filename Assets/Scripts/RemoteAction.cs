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
        rayInteractor.uiPressInput.manualPerformed = false; // Configure le statut par d�faut du Ray Interactor.
        rayInteractor.uiPressInput.manualValue = 1f;
    }

    /// <summary>
    /// Cette m�thode permet d'activer les interactions UI avec le Ray Interactor de la t�l�commande. Est con�ue pour aller dans la liste d'�v�nement Activated du composant Grab Interactable.
    /// </summary>
    public void Activate()
    {
        rayInteractor.uiPressInput.manualPerformed = true;
    }

    /// <summary>
    /// Cette m�thode permet de d�sactiver les interactions UI avec le Ray Interactor de la t�l�commande. Est con�ue pour aller dans la liste d'�v�nement Deactivated du composant Grab Interactable.
    /// </summary>
    public void Deactivate()
    {
        rayInteractor.uiPressInput.manualPerformed = false;
    }
}
