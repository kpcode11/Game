using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ExitButtonHandler : MonoBehaviour
{
    public Button exitButton;

    void Start()
    {
        if (exitButton == null)
        {
            exitButton = GetComponent<Button>();
        }
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    void OnExitButtonClick()
    {
        SceneManager.LoadScene("StartMenu"); // Replace "MainMenu" with the name of your start menu scene
    }
}
