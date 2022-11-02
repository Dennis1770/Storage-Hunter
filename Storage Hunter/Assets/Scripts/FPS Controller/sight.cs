using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class sight : MonoBehaviour
{
    public TMP_Text mouseSensTextValue = null;
    public Slider slider;
    public float sliderSenseValue;
    public static float mouseSensitivity = 300; //speed of the mouse
    public Transform player; //player model
    float xRotation;
    string activeScene;
    
    // Start is called before the first frame update
    void Start()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("currentSensitivity", mouseSensitivity);
        slider.value = PlayerPrefs.GetFloat("saveSenseSlider");
        activeScene = SceneManager.GetActiveScene().name;
        Debug.Log("Active Scene:" + activeScene);
        if (activeScene == "MainMenu")
        {
            // do nothing with the cursor
        }
        else if (activeScene != "MainMenu")
        {
            Cursor.lockState = CursorLockMode.Locked; //locks and hides mouse cursor to the center of the screen
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        //mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime; // mouse position * mouse sensitivity * every updated frame
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime; // mouse position * mouse sensitivity * every updated frame

        xRotation -= mouseY; //rotation on x-axis
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //rotation doesnt go pass minimum or maximum

        //rotate camera and orientation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX); //rotates player model


        //Updating Sense Value constantly
        mouseSensTextValue.text = mouseSensitivity.ToString("");


    }

    public void AdjustSensitivity(float sensSpeed)
    {
        mouseSensitivity = sensSpeed * 10;
        mouseSensitivity = Mathf.RoundToInt(sensSpeed);

        // saving slider value when changing scenes
        sliderSenseValue = sensSpeed;
        PlayerPrefs.SetFloat("saveSenseSlider", sliderSenseValue);
    }

}
