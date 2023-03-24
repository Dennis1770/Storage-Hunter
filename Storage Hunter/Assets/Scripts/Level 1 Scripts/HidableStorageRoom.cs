using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidableStorageRoom : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    [Min(1)]
    private float hitRange = 5;

    private RaycastHit hit;

    public playerMovement playerMovement;
    public sight Sight;

    private Animator StorageRoomAnim;

    public bool BlueDoorClosed = true;


    void Start()
    {
        StorageRoomAnim = GetComponent<Animator>();
    }


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

            if (Input.GetKeyDown(KeyCode.E) && hit.collider.gameObject.tag == "BlueDoor") // Checking if player Presses E on Storage Room Handle
            {

                // If Storage Room is closed, Open door through animation and set BlueDoorClosed to false
                if (BlueDoorClosed == true)
                {
                    BlueDoorClosed = false;
                    Debug.Log("BlueDoor is being opened");
                    StorageRoomAnim.SetBool("Opened", true);
                    StorageRoomAnim.SetBool("Closed", false);

                }
                else if (BlueDoorClosed == false)   // If Storage Room is open, close door through animation and set BlueDoorClosed to true
                {
                    BlueDoorClosed = true;
                    Debug.Log("BlueDoor is being closed");
                    StorageRoomAnim.SetBool("Closed", true);
                    StorageRoomAnim.SetBool("Opened", false);
                }

            }

        }

    }
}
