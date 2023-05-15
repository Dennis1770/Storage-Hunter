using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    //Michael made edits to this script to have it work cohesively with the DialogueManager.  Also added noiseValue for the monster to use.

    public CharacterController controller; //character controller

    //basic movement
    public float speed; //player speed
    public float gravity = -9.81f; //gravity of earth;

    public float resetSpeed;
    public float resetSprint;

    public float noiseValue = 0; //this is used by the monster to find the player

    public GameObject playerCamera;
    private bool isLocked; //used to lock the camera when the player selects dialogue
    private float cameraXAngle;
    private float cameraYAngle;
    private float cameraZAngle;

    Vector3 velocity; //stores current velocity

    //sprint
    public float sprint = 20f; //sprint increase

    sprintBar stamina; //sprintBar script
    private float takeStamina = 0.4f;

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

        stamina = GetComponent<sprintBar>(); //get components from the sprintBar script
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
                if (isLocked == false)
                {
                    //save the camera position
                    cameraXAngle = playerCamera.transform.eulerAngles.x;
                    cameraYAngle = playerCamera.transform.eulerAngles.y;
                    cameraZAngle = playerCamera.transform.eulerAngles.z;
                    isLocked = true;
                }
                //Debug.Log($"The camera should be locked at {cameraXAngle}, {cameraYAngle}, {cameraZAngle}");
                playerCamera.transform.eulerAngles = new Vector3(cameraXAngle, cameraYAngle, cameraZAngle); //lock the camera while talking to npc's
            }
            else Debug.LogError("playerCamera not found");
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
            isLocked = false;
        }

        //player movement
        float x = Input.GetAxis("Horizontal"); //input movement on x-axis
        float z = Input.GetAxis("Vertical"); //input movement on z-axis

        Vector3 move = transform.right * x + transform.forward * z; //directional movement on x and z axis

        controller.Move(move * speed * Time.deltaTime); //player movement * player speed * every updated frame

        velocity.y += gravity * Time.deltaTime; //velocity = gravity * time delta time
        controller.Move(velocity * Time.deltaTime); //velocity * time delta time

        float currentSpeed = move.magnitude * speed; //calculate the current speed of the player
        noiseValue = currentSpeed < resetSpeed ? 0f : (currentSpeed >= (sprint) ? 2f : 1f); //this is a nested ternary operator.  it changes the noiseValue depending on how fast the player is moving.

        //sprinting
        if (Input.GetKey(KeyCode.LeftShift) && stamina.currentSprint > 3f) //if left shift is pressed down, and the current stamina >= 10, add sprint to speed
        {

            speed = sprint;
            stamina.TakeStamina(takeStamina); //remove stamina from player

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || stamina.currentSprint <= 3f) //if left shift is released, subtract sprint from speed
        {
            speed = resetSpeed;
        }
    }


    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Monster") //if player makes contact with the monster game object, call on the EndGame function
        {
            SceneManager.LoadScene("GameOver"); //calls on EndGame funcation
        }
    }
}
