using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour
{
    private static ApplicationManager _this;

    // Start is called before the first frame update
    void Start()
    {
        if (_this != null)
        {
            Destroy(this);
        }
        else
        {
            _this = this;
            DontDestroyOnLoad(this);
        }
    }

    public static void LoadCite()
    {
        SceneManager.LoadScene(1);
    }

    public static void LoadRoom()
    {
        SceneManager.LoadScene(0);
    }
}
