using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class capturePhoto : MonoBehaviour
{
    
    //Script written by Andrew
    
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea; //display area of the picture
    [SerializeField] private GameObject photoFrame; //photo frame UI object

    [SerializeField] private GameObject closePhotoFrameUI; //close photo frame UI instructions

    [Header("Camera Flash")]
    [SerializeField] private GameObject cameraFlash; //point light object
    [SerializeField] private float flashTime; //how long will light flash for

    [Header("Photo Fader Effect")]
    [SerializeField] private Animator fadingAnimation; //image fade
    
    private Texture2D screenCapture; //screenshot
    private bool viewingPhoto; //is player looking at picture

    public Transform player; //player position
    public Transform monster; //monster position
    public float sightDistance; //view between player and monster
    public GameObject closeDoors; //close door game object

    // Start is called before the first frame update
    void Start()
    {

        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false); //region to read

    }

    // Update is called once per frame
    void Update()
    {

       // Vector3 distanceToMonster = player.position - transform.position; //calculate monster position
        //Vector3 distanceToPlayer = monster.position - transform.position; //calculate player position

        if (Vector3.Distance(player.position, monster.position) < sightDistance)
        {

            if (Input.GetKeyDown(KeyCode.Space)) //if player presses the space bar, take a screenshot
            {

                if (!viewingPhoto)
                {

                    StartCoroutine(CapturePhoto());

                }
                else
                {

                    RemovePhoto();

                }


            }

        }
        
    }

    IEnumerator CapturePhoto()
    {

        //Camera UI set false;
        viewingPhoto = true; //player is looking at photo
        
        yield return new WaitForEndOfFrame(); //make sure everything has ended

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height); //region of the screen to read

        screenCapture.ReadPixels(regionToRead, 0, 0, false); //capture the target area
        screenCapture.Apply(); //applies all set pixel changes

        ShowPhoto();

    }

    void ShowPhoto()
    {

        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f); //convert the picture to a UI
        photoDisplayArea.sprite = photoSprite; //photoDisplayArea = photoSprite

        photoFrame.SetActive(true); //photo frame object is active
        StartCoroutine(CameraFlashEffect());

        fadingAnimation.Play("PhotoFade"); //play photo fade animation

        closeDoors.SetActive(true); //activates closeDoors gameobject

        closePhotoFrameUI.SetActive(true);

    }

    IEnumerator CameraFlashEffect()
    {

        cameraFlash.SetActive(true); //make point light active
        yield return new WaitForSeconds(flashTime); //wait for flash time
        cameraFlash.SetActive(false); //point light is no longer active

    }    

    void RemovePhoto()
    {

        viewingPhoto = false; //not viewing photo
        photoFrame.SetActive(false); //photo frame object is not active
        //Camera UI true;

        closePhotoFrameUI.SetActive(false);

    }

}
