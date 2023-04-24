using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEscKey : MonoBehaviour
{
    //public playerMovement playerMovement;
    //public sight Sight;
    public GameObject escapeMenu;
    public bool showEscapeMenu {get; private set;}

    private void Awake()
    {
        escapeMenu.SetActive(false);
        showEscapeMenu = false;
    }
    private void Update()
    {
        Debug.Log(showEscapeMenu);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc Pressed!");

            if (showEscapeMenu == false) // if showEscapeMenu is false, unlock cursor, disable playerMovement script, showJournal to true, and show Journal Canvas
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                showEscapeMenu = true;
                escapeMenu.SetActive(true);

                Time.timeScale = 0; // pause game
            }
            else // if showJournal is true, lock cursor, enable playerMovement script, showJournal to false, and not show Journal Canvas
            {
                Time.timeScale = 1; // resume game

                //Cursor.lockState = CursorLockMode.Locked;
                //Cursor.visible = false;
                showEscapeMenu = false;
                escapeMenu.SetActive(false);
            }
        }
    }
    public void ResumeButton()
    {
        Time.timeScale = 1; // resume game

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        showEscapeMenu = false;
        escapeMenu.SetActive(false);
    }
}
