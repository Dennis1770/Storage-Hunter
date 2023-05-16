using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scripted by Aaron Lee
public class playerEscKey : MonoBehaviour
{

    public GameObject escapeMenu;
    public bool showEscapeMenu;


    private void Awake()
    {
        escapeMenu.SetActive(false);
        showEscapeMenu = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // If Esc is pressed, show EscapeMenu UI
        {
            Debug.Log("Esc Pressed!");

            if (showEscapeMenu == false)
            {
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

    public void ResumeButton() // Close Escape Menu and resume game
    {
        showEscapeMenu = false;
        escapeMenu.SetActive(false);
    }




}
