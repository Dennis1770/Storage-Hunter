using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Scripted by Aaron Lee
public class DockClues : MonoBehaviour
{

    [Header("Journal & Instruction UI")]
    public GameObject UIClueConfirmation;
    public GameObject UIClue1Revealed;
    public GameObject UIClue2Revealed;

    public GameObject UIStorageFacilityButtonRevealed;

    [Header("Objective Dialogue")]
    [SerializeField] private GameObject findAllCluesObjectiveUI;
    [SerializeField] private GameObject travelToStorageFacilityObjectiveUI;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip audioClip;

    [Header("Booleans")]
    public static bool dockClue1Achieved;
    public static bool dockClue2Achieved;


    private void Awake()
    {
        // Start scene with first Objective UI
        findAllCluesObjectiveUI.SetActive(true);
    }


    private void Update()
    {
        if (dockClue1Achieved == true)
        {
            // Making the UI Clue Text visible
            UIClue1Revealed.SetActive(true);
        }

        if (dockClue2Achieved == true)
        {
            // Making the UI Clue Text visible
            UIClue2Revealed.SetActive(true);
        }



        // If all clues are found in the dock scene, show Storage Facility Button in Journal UI, and update Objective
        if (dockClue1Achieved == true &&
            dockClue2Achieved == true)
        {
            UIStorageFacilityButtonRevealed.SetActive(true); 

            findAllCluesObjectiveUI.SetActive(false);
            travelToStorageFacilityObjectiveUI.SetActive(true);
        }


    }


    private void OnTriggerEnter(Collider collider)
    {
        // If player collides with an object named DockClue1, run code below
        if (collider.gameObject.tag == "DockClue1")
        {
            Debug.Log("Interacted with DockClue1");

            if (dockClue1Achieved == false)
            {

                dockClue1Achieved = true;

                //Player's first time interacting with DockClue2, audio plays
                audioSource.PlayOneShot(audioClip);
                Debug.Log("Playing pencil sfx");

                //UI pops up saying that the information is being added to the journal
                UIClueConfirmation.SetActive(true);
                StartCoroutine("ClueAcquired");

                // Making the UI Clue Text visible
                UIClue1Revealed.SetActive(true);
            }

        }

        // If player collides with an object named DockClue2, run code below
        if (collider.gameObject.tag == "DockClue2")
        {
            Debug.Log("Interacted with DockClue2");

            if (dockClue2Achieved == false)
            {

                dockClue2Achieved = true;

                //Player's first time interacting with DockClue2, audio plays
                audioSource.PlayOneShot(audioClip);
                Debug.Log("Playing pencil sfx");

                //UI pops up saying that the information is being added to the journal
                UIClueConfirmation.SetActive(true);
                StartCoroutine("ClueAcquired");

                // Making the UI Clue Text visible
                UIClue2Revealed.SetActive(true);
            }

        }

    }

    IEnumerator ClueAcquired()
    {
        // Wait 3 seconds and then turn UIClueConfirmation off
        yield return new WaitForSeconds(3);
        UIClueConfirmation.SetActive(false);

    }

}
