using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneButtonLoader : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ControlsMenu()
    {
        SceneManager.LoadScene("Controls Menu");
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("Settings Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }


}
