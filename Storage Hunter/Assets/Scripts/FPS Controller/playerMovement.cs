using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public CharacterController controller; //character controller

    //basic movement
    public float speed = 10f; //player speed

    //sprint
    public float sprint = 10f; //sprint increase

    //crouch
    

    


    // Update is called once per frame
    void Update()
    {
        //player movement
        float x = Input.GetAxis("Horizontal"); //input movement on x-axis
        float z = Input.GetAxis("Vertical"); //input movement on z-axis

        Vector3 move = transform.right * x + transform.forward * z; //directional movement on x and z axis

        controller.Move(move * speed * Time.deltaTime); //player movement * player speed * every updated frame

        //sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift)) //if left shift is pressed down, add sprint to speed
        {

            speed += sprint;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) //if left shift is released, subtract sprint from speed
        {

            speed -= sprint;

        }

        
        

        

    }

    

}
