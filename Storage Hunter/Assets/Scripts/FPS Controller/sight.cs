using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sight : MonoBehaviour
{

    public float mouseSensitivity = 500f; //speed of the mouse

    public Transform player; //player model

    float xRotation;
    
    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked; //locks and hides mouse cursor to the center of the screen

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
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.Rotate(Vector3.up * mouseX); //rotates player model

    }
}
