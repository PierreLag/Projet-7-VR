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
            mesh.material = selectedMaterial;   // Change le mat�riel du point d'int�r�t initial pour selui s�lectionn�
        }
    }

    /// <summary>
    /// Cette m�thode change l'apparance du point d'int�r�t courant vers le mat�riel d�s�lectionn�, et le nouveau point d'int�r�t vers le mat�riel s�lectionn�.
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
