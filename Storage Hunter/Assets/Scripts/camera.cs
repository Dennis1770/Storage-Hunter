using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class camera : MonoBehaviour
{

    public Camera playerCamera; //main camera
    public GameObject picturePlane; //where the image will load on

    private bool pictureTaken = false; //has the picture been taken? Set to false
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the space bar is pressed, and picture taken isn't false, take a screenshot with the camera, apply it to a plane, set picture taken to true, and load the next scene
        if(Input.GetKeyDown(KeyCode.Space) && !pictureTaken)
        {

            Texture2D picture = ScreenCapture.CaptureScreenshotAsTexture(); //take a screenshot of the cameras view

            picturePlane.GetComponent<Renderer>().material.mainTexture = picture; //apply the screenshot to a plane

            pictureTaken = true; //make pictureTaken true so only 1 image is taken

            StartCoroutine(LoadNextScene()); //load scene after delay

        }

    }

    IEnumerator LoadNextScene()
    {

        yield return new WaitForSeconds(2f); //wait 2 second before loading the scene

        SceneManager.LoadScene("GameOver"); //load game over scene

    }

}
