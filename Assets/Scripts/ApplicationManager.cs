using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEditor;

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

    /// <summary>
    /// Cette m�thode charge la sc�ne de la visite de la Cit�.
    /// </summary>
    public static void LoadCite()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Cette m�thode charge la sc�ne de la pi�ce d'accueil.
    /// </summary>
    public static void LoadRoom()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Cette m�thode permet d'afficher le menu d'options quand le bouton attribu� est appuy�.
    /// </summary>
    /// <param name="context">Les param�tres de contexte du bouton appuy�.</param>
    private void OnMenuButtonPressed(InputAction.CallbackContext context)
    {
        MenuController.GetThis().ToggleMenuDisplay();
    }

    /// <summary>
    /// Cette m�thode permet de quitter l'application.
    /// </summary>
    public static void QuitApplication()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
