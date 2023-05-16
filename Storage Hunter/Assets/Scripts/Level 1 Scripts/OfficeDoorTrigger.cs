using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Scripted by Aaron Lee
public class OfficeDoorTrigger : MonoBehaviour
{

    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private GameObject keypadUI;

    [SerializeField]
    [Min(1)]
    private float hitRange = 5;

    private RaycastHit hit;

    public playerMovement playerMovement;
    public sight Sight;

    public bool keypad_isOpen;

    private void Update()
    {
        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hitRange, Color.red);
        if (hit.collider != null)
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
        }

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);

            // If player raycast detects Keypad and player presses E, open KeypadUI
            if (Input.GetKeyDown(KeyCode.E) && hit.collider.gameObject.tag == "Keypad")
            {
                keypadUI.SetActive(true);

                keypad_isOpen = true; 
                Sight.enabled = false;

            }



        }




    }

    public void keypadClose()
    {
        keypadUI.SetActive(false);

        keypad_isOpen = false;
        //we handle playermovement and cursor behaviors in the playerMovement script
        //playerMovement.enabled = true;
        //Cursor.lockState = CursorLockMode.Locked;
        Sight.enabled = true;
    }
}
