using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorButton : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    [Min(1)]
    private float hitRange = 5;

    private RaycastHit hit;

    private bool playerInZone; //player is in button range
    public GameObject elevator; //elevator game object
    private bool buttonPressed; //is the elevator button pressed

    public Level1Clues level1Clues; // calling from the Level1Clues script

    // Start is called before the first frame update
    void Start()
    {
        
        playerInZone = false; //player isn't in button range
        buttonPressed = false; //button isn't pressed
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayerMask))
        {


            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(hit.transform.name);

                if (hit.transform.name == "Elevator Button")
                {
                    if (level1Clues.elevatorCardObtained == true)
                    {
                        Debug.Log("Player has elevator card!");
                        Debug.Log("Button is pressed");
                        buttonPressed = true; //button is pressed
                        gameObject.GetComponent<Animator>().Play("pushButton");
                    }
                    else if (level1Clues.elevatorCardObtained == false)
                    {
                        Debug.Log("Player doesn't have elevator card :c ");
                        level1Clues.NoElevatorCardIEnumerator();
                    }
                }


            }
        }

        /*
        if (playerInZone && Input.GetKeyDown(KeyCode.E)) //if the player is in the zone and pushes down E, play the following animations
        {


            if (level1Clues.elevatorCardObtained == true)
            {
                Debug.Log("Player has elevator card!");
                Debug.Log("Button is pressed");
                buttonPressed = true; //button is pressed
                gameObject.GetComponent<Animator>().Play("pushButton");
            }
            else if (level1Clues.elevatorCardObtained == false)
            {
                Debug.Log("Player doesn't have elevator card");
            }
                
            

        }
        */

       if(buttonPressed == true) //if button is pressed, play animation
        {

            elevator.GetComponent<Animator>().Play("openElevator");

        }


    }

    /*
    private void OnTriggerEnter(Collider other) //if player is in zone
    {
        
        if(other.gameObject.tag == "Player") //if collider detects player tag, player is in zone
        {

            playerInZone = true;
        }

    }

    private void OnTriggerExit(Collider other) //if player exits zone
    {
        
        if(other.gameObject.tag == "Player") //if collider doesn't detect player, player isn't in zone
        {

            playerInZone = false;

        }

    }

    */
    


}
