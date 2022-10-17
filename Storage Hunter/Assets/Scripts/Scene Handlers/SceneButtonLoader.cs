using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneButtonLoader : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Desk Intro");
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

    public void GameplayMenu()
    {
        SceneManager.LoadScene("Gameplay Menu");
    }

    public void GraphicsMenu()
    {
        SceneManager.LoadScene("Graphics Menu");
    }

    public void VolumeMenu()
    {
        SceneManager.LoadScene("Volume Menu");
    }

    public void DockScene()
    {
        SceneManager.LoadScene("Dock");
    }

    public void StorageScene()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ParkScene()
    {
        SceneManager.LoadScene("Park");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
