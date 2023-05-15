using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoors : MonoBehaviour
{

    //Script written by Andrew

    private bool doorsOpen; //are the doors open
    public Animator elevator; //elevator animator
    public GameObject openDoorObject; //game object script is attached to

    // Start is called before the first frame update
    void Start()
    {
        
        elevator.Play("openElevator"); //play animation
        doorsOpen = true; //doors are open

    }

    // Update is called once per frame
    void Update()
    {
        
        if(doorsOpen == true) //if the doors are open, destroy this object
        {

            Destroy(gameObject);

        }

    }
}
