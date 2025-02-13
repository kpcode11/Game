using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Level1()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void Level2()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void Level3()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void Level4()
    {
        SceneManager.LoadSceneAsync(5);
    }
}
