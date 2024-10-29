using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ApplicationManager : MonoBehaviour
{
    private static ApplicationManager _this;

    [SerializeField]
    private InputActionReference menuButton;

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

    private void OnEnable()
    {
        menuButton.action.performed += OnMenuButtonPressed;
    }

    private void OnDisable()
    {
        menuButton.action.performed -= OnMenuButtonPressed;
    }

    public static void LoadCite()
    {
        SceneManager.LoadScene(1);
    }

    public static void LoadRoom()
    {
        SceneManager.LoadScene(0);
    }

    private void OnMenuButtonPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Menu button pressed");
        MenuController.GetThis().ToggleMenuDisplay();
    }
}
