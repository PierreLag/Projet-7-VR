using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuController : MonoBehaviour
{
    private static MenuController _this;

    [SerializeField]
    private Canvas menuCanvas;
    [SerializeField]
    private Slider progressSlider;
    [SerializeField]
    private TextMeshProUGUI musicName;
    [SerializeField]
    private bool shouldDeactivateNearFarInteractorsOnLeave;

    private InteractionLayerMask defaultLayerMask;

    private void Start()
    {
        NearFarInteractor nearFarInteractor = FindObjectOfType<NearFarInteractor>(true);
        Debug.Log("Is Near-Far interactor used for the default null ? : " + (nearFarInteractor == null ? "Yes" : "No"));
        defaultLayerMask = nearFarInteractor.interactionLayers;
        progressSlider.value = AudioManager.GetGlobalVolume();
        _this = this;
    }

    private void Update()
    {
        AudioSource currentlyPlaying = AudioManager.GetCurrentlyPlaying();

        if (currentlyPlaying != null)
        {
            progressSlider.value = currentlyPlaying.time / currentlyPlaying.clip.length;    // Met à jour la barre de progrès de la musique
        }
        else
        {
            progressSlider.value = 0f;
        }
    }

    /// <summary>
    /// Cette méthode change le texte du champs montrant le nom de la musique, avec la musique qui se joue à l'heure actuelle.
    /// </summary>
    public void ChangeMusicName()
    {
        AudioSource currentlyPlaying = AudioManager.GetCurrentlyPlaying();
        if (currentlyPlaying == null)
        {
            musicName.text = "---";
        }
        else
        {
            musicName.text = currentlyPlaying.clip.name;
        }
    }

    /// <summary>
    /// Cette méthode active ou désactive l'affichage du menu d'options.
    /// </summary>
    public void ToggleMenuDisplay()
    {
        NearFarInteractor[] nearFarInteractors = FindObjectsByType<NearFarInteractor>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        menuCanvas.gameObject.SetActive(!menuCanvas.gameObject.activeSelf);
        if (menuCanvas.gameObject.activeSelf)
        {
            foreach(NearFarInteractor interactor in nearFarInteractors)
            {
                interactor.enableFarCasting = true;
                interactor.interactionLayers = new InteractionLayerMask();
            }
        }
        else
        {
            foreach (NearFarInteractor interactor in nearFarInteractors)
            {
                interactor.enableFarCasting = !shouldDeactivateNearFarInteractorsOnLeave;
                interactor.interactionLayers = defaultLayerMask;
            }
        }
    }

    /// <summary>
    /// Cette fonction retourne l'instance courante du menu.
    /// </summary>
    /// <returns>L'instance courante du menu d'options.</returns>
    public static MenuController GetThis()
    {
        return _this;
    }
}
