using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDialogue : MonoBehaviour
{


    [SerializeField]
    pickUpCamera pickUpCameraScript;

    [SerializeField]
    private GameObject needEvidenceUI;

    [SerializeField]
    private GameObject findCameraUI;

    [SerializeField]
    private GameObject foundCameraUI;

    [SerializeField]
    private GameObject pictureTimeUI;

    [SerializeField]
    private GameObject cameraInstructionsUI;

    [Header("Pickup Audio Clip")]
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Awake()
    {
        StartCoroutine(StartingDialogue());

    }

    IEnumerator StartingDialogue()
    {
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


}
