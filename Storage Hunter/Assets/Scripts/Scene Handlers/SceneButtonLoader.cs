using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneButtonLoader : MonoBehaviour
{

    public Animator animator; //fade in animation
    private int levelToLoad;

    public void PlayGame()
    {
        SceneManager.LoadScene("Desk Intro");
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;

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

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
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
        FadeToLevel(3);
        Debug.Log("Loading Dock");

    }

    public void StorageScene()
    {
        FadeToLevel(4);

    }

    public void ParkScene()
    {
        FadeToLevel(2);

    }



    public void ReturnButton()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void QuitGame()
    {
        Application.Quit();
    }


    public void FadeToLevel(int levelIndex)
    {

        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut"); //triggers the animator

    }

    public void OnFadeComplete()
    {

        SceneManager.LoadScene(levelToLoad);

    }
}
