using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorButton : MonoBehaviour
{


    private bool playerInZone; //player is in button range
    public GameObject elevator; //elevator game object
    private bool buttonPressed; //is the elevator button pressed
   
    
    
    // Start is called before the first frame update
    void Start()
    {

        playerInZone = false; //player isn't in button range
        buttonPressed = false; //button isn't pressed
       

    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerInZone && Input.GetKeyDown(KeyCode.E)) //if the player is in the zone and pushes down E, play the following animations
        {

            gameObject.GetComponent<Animator>().Play("pushButton");
            buttonPressed = true; //button is pressed
            
            

        }

       if(buttonPressed == true) //if button is pressed, play animation
        {

            elevator.GetComponent<Animator>().Play("openElevator");
            //buttonPressed = false;

        }


    }


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


    


}
