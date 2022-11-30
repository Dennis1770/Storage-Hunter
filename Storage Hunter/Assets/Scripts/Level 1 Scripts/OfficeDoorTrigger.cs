using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfficeDoorTrigger: MonoBehaviour
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


            if (Input.GetKeyDown(KeyCode.E) && hit.collider.gameObject.tag == "Keypad")
            {

                keypadUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                playerMovement.enabled = false;
                Sight.enabled = false;


            }



        }




    }

    public void keypadClose()
    {
        keypadUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        playerMovement.enabled = true;
        Sight.enabled = true;
    }
}
