using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Clues : MonoBehaviour
{

    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private GameObject startingDialogueUI;

    [SerializeField]
    private GameObject darkDialogueUI;
    [SerializeField]
    private GameObject findLightsourceUI;

    [SerializeField]
    private GameObject foundLightsourceUI;

    [SerializeField]
    private GameObject flashlightInstructionUI;

    [SerializeField]
    private GameObject crumbledPaperUI;

    [SerializeField]
    private GameObject noElevatorCardUI;

    [SerializeField]
    private GameObject obtainedElevatorCardUI;

    [SerializeField]
    [Min(1)]
    private float hitRange = 5;

    private RaycastHit hit;

    public bool paper_isOpen;   //public bool for player movement script 


    [Header("Pickup Audio Clip")]
    public AudioSource audioSource;
    public AudioClip audioClip;

    public playerMovement playerMovement;
    public sight Sight;
    public bool elevatorCardObtained = false;


    private void Awake()
    {
        StartCoroutine(StartingDialogue());
    }
    private void Update()
    {


        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayerMask))
        {


            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(hit.transform.name);

                if (hit.transform.name == "Crumbled Paper")
                {
                    // Play pickup sfx
                    audioSource.PlayOneShot(audioClip);
                    Debug.Log("Playing pickup sfx");

                    // Enable crumbledPaperUI to appear, cursor is visible, player unable to move
                    crumbledPaperUI.SetActive(true);
                    //we handle playermovement and cursor behaviors in the playerMovement script
                    //Cursor.lockState = CursorLockMode.None;
                    //playerMovement.enabled = false;
                    Sight.enabled = false;

                    paper_isOpen = true;
                }

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

                if (hit.transform.name == "Flashlight")
                {
                    // Play pickup sfx
                    audioSource.PlayOneShot(audioClip);
                    Debug.Log("Playing pickup sfx");

                    StartCoroutine(foundLightsource());
                }

            }
        }



    }

    public void crumbledPaperClose()
    {
        // resumes actions after crumbledPaperUI is closed
        crumbledPaperUI.SetActive(false);
        //we handle playermovement and cursor behaviors in the playerMovement script
        //Cursor.lockState = CursorLockMode.Locked;
        //playerMovement.enabled = true;
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

        foundLightsourceUI.SetActive(true);
        yield return new WaitForSeconds(3);
        foundLightsourceUI.SetActive(false);

        flashlightInstructionUI.SetActive(true);
        yield return new WaitForSeconds(3);
        flashlightInstructionUI.SetActive(false);
    }

    IEnumerator NoElevatorCard()
    {
        noElevatorCardUI.SetActive(true);
        yield return new WaitForSeconds(3);
        noElevatorCardUI.SetActive(false);

    }

    IEnumerator ObtainedElevatorCard()
    {
        obtainedElevatorCardUI.SetActive(true);
        yield return new WaitForSeconds(3);
        obtainedElevatorCardUI.SetActive(false);

    }




}
