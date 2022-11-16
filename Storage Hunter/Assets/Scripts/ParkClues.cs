using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkClues : MonoBehaviour
{

    public static bool parkClue1Achieved;
    public static bool parkClue2Achieved;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public GameObject UIClueConfirmation;
    public GameObject UIClue1Revealed;
    public GameObject UIClue2Revealed;

    public GameObject pickableObject1;
    private void Update()
    {
        if (parkClue1Achieved == true)
        {
            // Making the UI Clue Text visible
            UIClue1Revealed.SetActive(true);
        }

        if (parkClue2Achieved == true)
        {
            // Making the UI Clue Text visible
            UIClue2Revealed.SetActive(true);
        }


        // Checking to see if PickableObject1 doesn't exist in the scene 
        if (pickableObject1 == null)
        {
            Debug.Log("Interacted with ParkClue1");

            if (parkClue1Achieved == false)
            {

                parkClue1Achieved = true;

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



        if (collider.gameObject.tag == "ParkClue2")
        {
            Debug.Log("Interacted with ParkClue2");

            if (parkClue2Achieved == false)
            {

                parkClue2Achieved = true;

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
