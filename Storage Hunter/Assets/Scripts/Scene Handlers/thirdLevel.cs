using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class thirdLevel : MonoBehaviour
{
   
    //Scriot wirtten by Andrew
    
    private bool playerInElevator; //is the player in the elevator
    private bool doorsClosed; //are the doors closed
    public Animator elevator; //elevator animator

    private void OnTriggerEnter(Collider other) //if player is in zone
    {

        if (other.gameObject.tag == "Player") //if collider detects player tag, player is in the elevator
        {

            playerInElevator = true; //player is in the elevator
            Debug.Log("Player is in elevator");

        }

    }

    void Update()
    {

        if (playerInElevator == true) //if the player is in the elevator, close the doors
        {

            elevator.Play("closeElevator");
            Invoke("DoorsClosed", 3); //wait 5 seconds after the doors are closed

        }

        if (doorsClosed == true) //if the doors are closed, load the next level
        {

            SceneManager.LoadScene("Level 3");

        }

    }

    void DoorsClosed()
    {

        doorsClosed = true; //the doors are closed
        Debug.Log("Doors are closed");

    }
}
