using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJournal : MonoBehaviour
{
    public playerMovement playerMovement;
    public sight Sight;
    public GameObject journal;
    public bool showJournal;


    private void Awake()
    {
        // journal = GetComponent<GameObject>(); 
        journal.SetActive(false);
        showJournal = false;
        Sight = FindObjectOfType<sight>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Tab Pressed!");

            if (showJournal == false) // if showJournal is false, unlock cursor, disable playerMovement script, showJournal to true, and show Journal Canvas
            {
                //Sight.enabled = false;

                Sight.allowRotation = false;
                showJournal = true;
                journal.SetActive(true);

                //we handle playermovement and cursor behaviors in the playerMovement script
                //Cursor.lockState = CursorLockMode.None;
                //playerMovement.enabled = false;
            }
            else // if showJournal is true, lock cursor, enable playerMovement script, showJournal to false, and not show Journal Canvas
            {
                //Sight.enabled = true;
                Sight.allowRotation = true;
                showJournal = false;
                journal.SetActive(false);

                //we handle playermovement and cursor behaviors in the playerMovement script
                //playerMovement.enabled = true;
                //Cursor.lockState = CursorLockMode.Locked;
            }



        }
    }




}
