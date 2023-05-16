using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scripted by Aaron Lee
public class playerJournal : MonoBehaviour
{
    public playerMovement playerMovement;
    public sight Sight;
    public GameObject journal;
    public bool showJournal;


    private void Awake()
    {
        journal.SetActive(false);
        showJournal = false;
        Sight = FindObjectOfType<sight>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // If Tab was pressed, turn On/Off Journal UI
        {
            Debug.Log("Tab Pressed!");

            if (showJournal == false) 
            {
                Sight.allowRotation = false;
                showJournal = true;
                journal.SetActive(true);
            }
            else 
            {
                Sight.allowRotation = true;
                showJournal = false;
                journal.SetActive(false);

            }
        }
    }




}
