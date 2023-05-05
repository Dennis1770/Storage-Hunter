using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEscKey : MonoBehaviour
{
    //public playerMovement playerMovement;
    //public sight Sight;
    public GameObject escapeMenu;
    public bool showEscapeMenu;


    private void Awake()
    {
        escapeMenu.SetActive(false);
        showEscapeMenu = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc Pressed!");

            if (showEscapeMenu == false) // if showEscapeMenu is false, unlock cursor, disable playerMovement script, showJournal to true, and show Journal Canvas
            {
                //Cursor.lockState = CursorLockMode.None;
                //Cursor.visible = true;
                showEscapeMenu = true;
                escapeMenu.SetActive(true);
            }
        }
        
        if(showEscapeMenu == true)
        {
            Time.timeScale = 0; // pause game
        }
        else if(showEscapeMenu == false)
        {
            Time.timeScale = 1; // resume game
        }

    }

    public void ResumeButton()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        
        showEscapeMenu = false;
        escapeMenu.SetActive(false);
    }




}
