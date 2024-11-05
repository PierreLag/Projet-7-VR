using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POIColourChanger : MonoBehaviour
{
    private static GameObject currentPOI;

    [SerializeField]
    private GameObject initialPOI;
    [SerializeField]
    private Material selectedMaterial;
    [SerializeField]
    private Material unselectedMaterial;

    // Start is called before the first frame update
    void Start()
    {
        currentPOI = initialPOI;
        MeshRenderer[] meshes = currentPOI.GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer mesh in meshes)
        {
            mesh.material = selectedMaterial;   // Change le matériel du point d'intérêt initial pour selui sélectionné
        }
    }

    /// <summary>
    /// Cette méthode change l'apparance du point d'intérêt courant vers le matériel désélectionné, et le nouveau point d'intérêt vers le matériel sélectionné.
    /// </summary>
    /// <param name="pointOfInterest"></param>
    public void NewSelection(GameObject pointOfInterest)
    {

        MeshRenderer[] meshes = currentPOI.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in meshes)
        {
            mesh.material = unselectedMaterial;
        }

        currentPOI = pointOfInterest;
        meshes = currentPOI.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in meshes)
        {
            mesh.material = selectedMaterial;
        }
    }
}
