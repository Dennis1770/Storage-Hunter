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

    public float noiseValue = 0; //this is used by the monster to find the player

    public GameObject playerCamera;

    Vector3 velocity; //stores current velocity

    //sprint
    public float sprint = 10f; //sprint increase

    //crouch
    //public float crouchSpeed; //crouch speed
    //public float crouchYScale; //crouching height
    // private float startYScale; //starting y position
    // private KeyCode crouchKey = KeyCode.LeftControl; //key board key for crouching

    //Scripts which pull up UI (used to manage when the player can and cannot see their cursor)
    private OfficeDoorTrigger keypad;
    private playerJournal journal;
    private Level1Clues crumpledPaper;

    private int currentSceneIndex; //current scene save

    playerEscKey playerEscKeyInstance;



    private void Start()
    {
        //references to scripts which handle UI elements
        keypad = GameObject.FindObjectOfType<OfficeDoorTrigger>();
        journal = GameObject.FindObjectOfType<playerJournal>();
        crumpledPaper = GameObject.FindObjectOfType<Level1Clues>();

        //startYScale = transform.localScale.y; //starting y position
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //collects information on active scene
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex); //saves active scene

        playerEscKeyInstance = FindObjectOfType<playerEscKey>();

    }




    // Update is called once per frame
    void Update()
    {
        //show mouse for dialogue
        if (DialogueManager.GetInstance() != null && DialogueManager.GetInstance().dialogueIsPlaying)
        {
            Cursor.lockState = CursorLockMode.None; // unlock the cursor
            Cursor.visible = true; // show the cursor to make it easier for the player to select dialogue
            if (playerCamera != null)
            {
                playerCamera.transform.eulerAngles = new Vector3(0, playerCamera.transform.eulerAngles.y, 0); //prevent the player from looking at their feet when selecting dialogue
            }
            return;
        }
        //show mouse for ui
        else if ((playerEscKeyInstance != null && playerEscKeyInstance.showEscapeMenu == true) || (keypad != null && keypad.keypad_isOpen == true) || (journal != null && journal.showJournal == true) || (crumpledPaper != null && crumpledPaper.paper_isOpen == true))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        //hide mouse otherwise
        else
        {
            Cursor.lockState = CursorLockMode.Locked; // lock the cursor
            Cursor.visible = false; // hide the cursor again
        }

        //player movement
        float x = Input.GetAxis("Horizontal"); //input movement on x-axis
        float z = Input.GetAxis("Vertical"); //input movement on z-axis

        Vector3 move = transform.right * x + transform.forward * z; //directional movement on x and z axis

        controller.Move(move * speed * Time.deltaTime); //player movement * player speed * every updated frame

        velocity.y += gravity * Time.deltaTime; //velocity = gravity * time delta time
        controller.Move(velocity * Time.deltaTime); //velocity * time delta time

        float currentSpeed = move.magnitude * speed; //calculate the current speed of the player
        noiseValue = currentSpeed < resetSpeed ? 0f : (currentSpeed >= (resetSpeed + sprint) ? 2f : 1f); //this is a nested ternary operator.  it changes the noiseValue depending on how fast the player is moving.

        //sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift)) //if left shift is pressed down, add sprint to speed
        {
            speed += sprint;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) //if left shift is released, subtract sprint from speed
        {
            speed = resetSpeed;
        }


        /* if(Input.GetKeyDown(crouchKey)) //if left control is pressed, player will crouch
         {
             transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z); //changes y scale of the player
             //Rigidbody.AddForce(Vector3.down * 5f, ForceMode.Impulse); //pushes player model down

         }
         else if(Input.GetKeyUp(crouchKey)) //if left control key is lifted, player will stand
         {
             transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z); //changes y scale of the player
         }  */
    }


    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Monster") //if player makes contact with the monster game object, call on the EndGame function
        {

            SceneManager.LoadScene("GameOver"); //calls on EndGame funcation

        }
    }
}
