using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DevUIRenderer : MonoBehaviour
{
    int avgFPS;
    int triangleCount;
    [SerializeField]
    private TextMeshProUGUI fpsDisplay;
    [SerializeField]
    private TextMeshProUGUI triangleDisplay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DisplayFrameRate", 1, 1);
    }

    private void DisplayFrameRate()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFPS = (int)current;
        fpsDisplay.text = "FPS : " + avgFPS;
    }

    private void DisplayTriangleCount()
    {

    }
}
