using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Scripted by Aaron Lee
public class Level1Clues : MonoBehaviour
{

    [Header("Dialogue UI")]
    [SerializeField] private GameObject startingDialogueUI;
    [SerializeField] private GameObject darkDialogueUI;
    [SerializeField] private GameObject findLightsourceUI;
    [SerializeField] private GameObject foundLightsourceUI;
    [SerializeField] private GameObject flashlightInstructionUI;
    [SerializeField] private GameObject crumbledPaperUI;
    [SerializeField] private GameObject noElevatorCardUI;
    [SerializeField] private GameObject obtainedElevatorCardUI;

    [Header("Objective UI")]
    [SerializeField] private GameObject findLightsourceObjectiveUI;
    [SerializeField] private GameObject accessElevatorObjectiveUI;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip audioClip;

    [Header("Raycast")]
    public playerMovement playerMovement;
    public sight Sight;
    [SerializeField] private LayerMask pickableLayerMask;
    [SerializeField] private Transform playerCameraTransform;
    private RaycastHit hit;
    [SerializeField]
    [Min(1)]
    private float hitRange = 5;

    [Header("Booleans")]
    public bool flashlightObtained = false;
    public bool elevatorCardObtained = false;
    public bool paper_isOpen;

    private void Awake()
    {
        StartCoroutine(StartingDialogue());
        findLightsourceObjectiveUI.SetActive(true);

    }
    private void Update()
    {


        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayerMask))
        {


            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(hit.transform.name);

                // if player finds an object named Crumbled Paper, run code below
                if (hit.transform.name == "Crumbled Paper")
                {
                    // Play pickup sfx
                    audioSource.PlayOneShot(audioClip);
                    Debug.Log("Playing pickup sfx");

                    // show crumbledPaperUI
                    crumbledPaperUI.SetActive(true);
                    Sight.enabled = false;

                    paper_isOpen = true;
                }

                // if player finds an object named Elevator Card, run code below
                if (hit.transform.name == "Elevator Card")
                {
                    // Play pickup sfx
                    audioSource.PlayOneShot(audioClip);
                    Debug.Log("Playing pickup sfx");

                    //Destroy Elevator card
                    Destroy(hit.transform.gameObject);

                    //Obtained elevatorCard
                    elevatorCardObtained = true;

                    ObtainedElevatorCardIEnumerator();
                }

                // if player finds an object named Flashlight, run code below
                if (hit.transform.name == "Flashlight")
                {
                    // Play pickup sfx
                    audioSource.PlayOneShot(audioClip);
                    Debug.Log("Playing pickup sfx");

                    flashlightObtained = true;
                    FlashlightObtainedObjective();
                    
                    StartCoroutine(foundLightsource());
                }

            }
        }



    }

    public void crumbledPaperClose()
    {
        // resumes actions after crumbledPaperUI is closed
        crumbledPaperUI.SetActive(false);
        paper_isOpen = false;
        Sight.enabled = true;
    }


    public void NoElevatorCardIEnumerator()
    {
        StartCoroutine(NoElevatorCard());
    }

    public void ObtainedElevatorCardIEnumerator()
    {
        StartCoroutine(ObtainedElevatorCard());
    }

    IEnumerator StartingDialogue()
    {
        // Turns On/Off UI after a few seconds
        yield return new WaitForSeconds(1);
        startingDialogueUI.SetActive(true);
        yield return new WaitForSeconds(3);
        startingDialogueUI.SetActive(false);

        yield return new WaitForSeconds(3);
        darkDialogueUI.SetActive(true);
        yield return new WaitForSeconds(3);
        darkDialogueUI.SetActive(false);

        findLightsourceUI.SetActive(true);
        yield return new WaitForSeconds(3);
        findLightsourceUI.SetActive(false);
    }

    IEnumerator foundLightsource()
    {
        // Turns On/Off UI after a few seconds
        foundLightsourceUI.SetActive(true);
        yield return new WaitForSeconds(3);
        foundLightsourceUI.SetActive(false);

        flashlightInstructionUI.SetActive(true);
        yield return new WaitForSeconds(3);
        flashlightInstructionUI.SetActive(false);
    }

    IEnumerator NoElevatorCard()
    {
        // Turns On/Off UI after a few seconds
        noElevatorCardUI.SetActive(true);
        yield return new WaitForSeconds(3);
        noElevatorCardUI.SetActive(false);

    }

    IEnumerator ObtainedElevatorCard()
    {
        // Turns On/Off UI after a few seconds
        obtainedElevatorCardUI.SetActive(true);
        yield return new WaitForSeconds(3);
        obtainedElevatorCardUI.SetActive(false);

    }

    private void FlashlightObtainedObjective()
    {
        // Turns On/Off UI after a few seconds
        if (flashlightObtained == true)
        {
            findLightsourceObjectiveUI.SetActive(false);
            accessElevatorObjectiveUI.SetActive(true);
        }

    }


}
