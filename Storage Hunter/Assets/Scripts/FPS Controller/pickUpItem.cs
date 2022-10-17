using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpItem : MonoBehaviour
{

    public Flashlight flashlightScript; //calls on flashlight script
    public Rigidbody rb; //item rigidbody
    public Collider coll; //object box collider
    public Transform player, hand, mainCamera; //position of the player hand and camera objects
    public float pickUpRange; //distance to pick up object
    public bool holding; //is the player holding the object


    void Start()
    {
        
        if(!holding) //if player isn't holding the flashlight at start, then the flashlight script won't function, and the object's rigidbody and collider aren't active
        {
            
            flashlightScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;

        }

        if(holding) //if player is holding the flashlight at start, then the flashlight script works, the rigidboidy is active and the collider is active
        {

            flashlightScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;

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

        holding = true; //player is holding the item

        //sets objects transform position to the hand object
        transform.SetParent(hand);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        flashlightScript.enabled = true; //flashlight works when in players hand

        //both are trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

    }

}
