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
    public float crouchSpeed; //crouch speed
    public float crouchYScale; //crouching height
    private float startYScale; //starting y position
    private KeyCode crouchKey = KeyCode.LeftControl; //key board key for crouching

    private void Start()
    {

        startYScale = transform.localScale.y; //starting y position

    }




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

        
        if(Input.GetKeyDown(crouchKey)) //if left control is pressed, player will crouch
        {

            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z); //changes y scale of the player
            //Rigidbody.AddForce(Vector3.down * 5f, ForceMode.Impulse); //pushes player model down

        }
        else if(Input.GetKeyUp(crouchKey)) //if left control key is lifted, player will stand
        {

            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z); //changes y scale of the player

        }
        

    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        
        if(collisionInfo.collider.tag == "Monster") //if player makes contact with the monster game object, call on the EndGame function
        {

            FindObjectOfType<gameManager>().EndGame(); //calls on EndGame funcation

        }


    }



}
