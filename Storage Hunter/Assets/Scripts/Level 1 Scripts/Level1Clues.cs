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
    private GameObject crumbledPaperUI;

    [SerializeField]
    private GameObject noElevatorCardUI;

    [SerializeField]
    private GameObject obtainedElevatorCardUI;

    [SerializeField]
    [Min(1)]
    private float hitRange = 5;

    private RaycastHit hit;


    [Header("Pickup Audio Clip")]
    public AudioSource audioSource;
    public AudioClip audioClip;

    public playerMovement playerMovement;
    public sight Sight;
    public bool elevatorCardObtained = false;

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
                    Cursor.lockState = CursorLockMode.None;
                    playerMovement.enabled = false;
                    Sight.enabled = false;
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

            }
        }

    }

    public void crumbledPaperClose()
    {
        // resumes actions after crumbledPaperUI is closed
        crumbledPaperUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        playerMovement.enabled = true;
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
