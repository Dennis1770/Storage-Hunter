using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{

    public CharacterController controller; //character controller

    //basic movement
    public float speed = 10f; //player speed
    public float gravity = -9.81f; //gravity of earth;

    public float resetSpeed = 10f;
    public float resetSprint = 10f;
    Vector3 velocity; //stores current velocity

    //sprint
    public float sprint = 10f; //sprint increase

    //crouch
    public float crouchSpeed; //crouch speed
    public float crouchYScale; //crouching height
    private float startYScale; //starting y position
    private KeyCode crouchKey = KeyCode.LeftControl; //key board key for crouching

    private int currentSceneIndex; //current scene save

    private void Start()
    {

        startYScale = transform.localScale.y; //starting y position
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //collects information on active scene
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex); //saves active scene

    }




    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying) //freeze the player while they talk to npc's
        {
            return;
        }

        //player movement
        float x = Input.GetAxis("Horizontal"); //input movement on x-axis
        float z = Input.GetAxis("Vertical"); //input movement on z-axis

        Vector3 move = transform.right * x + transform.forward * z; //directional movement on x and z axis

        controller.Move(move * speed * Time.deltaTime); //player movement * player speed * every updated frame

        velocity.y += gravity * Time.deltaTime; //velocity = gravity * time delta time
        controller.Move(velocity * Time.deltaTime); //velocity * time delta time

        //sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift)) //if left shift is pressed down, add sprint to speed
        {

            speed += sprint;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) //if left shift is released, subtract sprint from speed
        {

            speed = resetSpeed;

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
