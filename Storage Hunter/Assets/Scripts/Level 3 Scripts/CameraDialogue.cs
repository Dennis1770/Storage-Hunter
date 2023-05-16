using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Scripted by Aaron Lee
public class CameraDialogue : MonoBehaviour
{


    [SerializeField] pickUpCamera pickUpCameraScript;

    [SerializeField] private GameObject needEvidenceUI;

    [SerializeField] private GameObject findCameraUI;

    [SerializeField] private GameObject foundCameraUI;

    [SerializeField] private GameObject pictureTimeUI;

    [SerializeField] private GameObject elevatorTimeUI;

    [SerializeField]
    private GameObject cameraInstructionsUI;

    [Header("Pickup Audio Clip")]
    public AudioSource audioSource;
    public AudioClip audioClip;

    [Header("Objective Dialogue")]
    [SerializeField] private GameObject findCameraObjectiveUI;
    [SerializeField] private GameObject takePictureObjectiveUI;
    [SerializeField] private GameObject returnToElevatorObjectiveUI;

    private void Awake()
    {
        // Starting dialogue played on awake so the player understands what to do
        StartCoroutine(StartingDialogue());
        findCameraObjectiveUI.SetActive(true);

    }

    IEnumerator StartingDialogue()
    {
        // Turn On/Off UI after a few seconds
        yield return new WaitForSeconds(1);
        needEvidenceUI.SetActive(true);
        yield return new WaitForSeconds(3);
        needEvidenceUI.SetActive(false);

        findCameraUI.SetActive(true);
        yield return new WaitForSeconds(3);
        findCameraUI.SetActive(false);
    }



    public IEnumerator CameraTime()
    {
        // Turn On/Off UI after a few seconds
        findCameraObjectiveUI.SetActive(false);
        takePictureObjectiveUI.SetActive(true);

        foundCameraUI.SetActive(true);
        yield return new WaitForSeconds(3);
        foundCameraUI.SetActive(false);

        pictureTimeUI.SetActive(true);
        yield return new WaitForSeconds(3);
        pictureTimeUI.SetActive(false);

        cameraInstructionsUI.SetActive(true);
        yield return new WaitForSeconds(3);
        cameraInstructionsUI.SetActive(false);
    }


    public void ReturnToElevatorMethod()
    {
        // Picture has been taken and Return to elevator objective is shown
        takePictureObjectiveUI.SetActive(false);
        returnToElevatorObjectiveUI.SetActive(true);
        
    }

}
