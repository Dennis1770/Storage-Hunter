using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpCamera : MonoBehaviour
{

   //Script written by Andrew
    
    public GameObject playerCamera; //camera game object
    public Transform player; //player position
    public float pickUpRange; //how far player is to pick up object

    public CameraDialogue cameraDialogue;
    public bool holding; //is player holding the camera
    
    // Start is called before the first frame update
    void Start()
    {

        

        
        if(!holding) //if the player isn't holding the camera, set script false
        {

            playerCamera.GetComponent<capturePhoto>().enabled = false; //disable script

        }

        if(holding) //if player is holding the camera, set script true
        {

            playerCamera.GetComponent<capturePhoto>().enabled = true; //enable script
            playerCamera.GetComponent<MeshRenderer>().enabled = false; //disable mesh renderer

        }

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 distanceToPlayer = player.position - transform.position; //calculate player position
        //If player is in range of object and presses the E key, call the pickup function
        if (distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E))
        {

            PickUp();

        }

    }

    private void PickUp()
    {

        holding = true; //player is holding the camera
        playerCamera.GetComponent<capturePhoto>().enabled = true; //enable script
        playerCamera.GetComponent<MeshRenderer>().enabled = false; //disable mesh renderer

        StartCoroutine(cameraDialogue.CameraTime());

    }

}
