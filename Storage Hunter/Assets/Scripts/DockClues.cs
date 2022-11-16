using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockClues : MonoBehaviour
{

    public static bool dockClue1Achieved;
    public static bool dockClue2Achieved;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public GameObject UIClueConfirmation;
    public GameObject UIClue1Revealed;
    public GameObject UIClue2Revealed;

    public GameObject pickableObject1;
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


        // Checking to see if PickableObject1 doesn't exist in the scene 
        if (pickableObject1 == null)
        {
            Debug.Log("Interacted with DockClue1");

            if (dockClue1Achieved == false)
            {

                dockClue1Achieved = true;

                // Player's first time interacting with DockClue1, audio plays
                audioSource.PlayOneShot(audioClip);
                Debug.Log("Playing pencil sfx");


                UIClueConfirmation.SetActive(true);
                StartCoroutine("ClueAcquired");


                // Making the UI Clue Text visible
                UIClue1Revealed.SetActive(true);

            }

        }
    }


    private void OnTriggerEnter(Collider collider)
    {



        if (collider.gameObject.tag == "DockClue2")
        {
            Debug.Log("Interacted with DockClue2");

            if (dockClue2Achieved == false)
            {

                dockClue2Achieved = true;

                // Player's first time interacting with DockClue2, audio plays
                audioSource.PlayOneShot(audioClip);
                Debug.Log("Playing pencil sfx");

                // UI pops up saying that the information is being added to the journal
                UIClueConfirmation.SetActive(true);
                StartCoroutine("ClueAcquired");

                // Making the UI Clue Text visible
                UIClue2Revealed.SetActive(true);
            }

        }

    }

    IEnumerator ClueAcquired()
    {
        yield return new WaitForSeconds(3);
        UIClueConfirmation.SetActive(false);

    }

}
