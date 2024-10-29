using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class MenuController : MonoBehaviour
{
    private static MenuController _this;

    [SerializeField]
    private Canvas menuCanvas;
    [SerializeField]
    private Slider progressSlider;
    [SerializeField]
    private TextMeshProUGUI musicName;

    // Start is called before the first frame update
    void Awake()
    {
        if (_this != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _this = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        AudioSource currentlyPlaying = AudioManager.GetCurrentlyPlaying();

        if (currentlyPlaying != null)
        {
            progressSlider.value = currentlyPlaying.time / currentlyPlaying.clip.length;
        }
    }

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

    public void ToggleMenuDisplay()
    {
        menuCanvas.enabled = !menuCanvas.enabled;
    }

    public static MenuController GetThis()
    {
        return _this;
    }
}
