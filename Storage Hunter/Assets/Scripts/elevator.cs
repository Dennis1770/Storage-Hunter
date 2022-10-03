using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{


    private bool playerInZone; //player is in button range
    
    
    // Start is called before the first frame update
    void Start()
    {

        playerInZone = false; //player isn't in button range

    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerInZone && Input.GetKeyDown(KeyCode.E)) //if the player is in the zone and pushes down E, play the following animations
        {

            gameObject.GetComponent<Animator>().Play("pushButton");
            
            

        }

    }


    private void OnTriggerEnter(Collider other) //if player is in zone
    {
        
        if(other.gameObject.tag == "Player")
        {

            playerInZone = true;

        }

    }

    private void OnTriggerExit(Collider other) //if player exits zone
    {
        
        if(other.gameObject.tag == "Player")
        {

            playerInZone = false;

        }

    }


    


}
