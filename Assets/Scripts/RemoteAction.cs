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
        rayInteractor.uiPressInput.manualPerformed = false;
        rayInteractor.uiPressInput.manualValue = 1f;
    }

    public void Activate()
    {
        rayInteractor.uiPressInput.manualPerformed = true;
    }

    public void Deactivate()
    {
        rayInteractor.uiPressInput.manualPerformed = false;
    }
}
