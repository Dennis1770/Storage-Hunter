using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revealCursor : MonoBehaviour
{
    // Use this script to initialize any scene without a character controller
    void Awake()
    {
        ShowMouse();
    }

    private void ShowMouse()
    {
        Cursor.lockState = CursorLockMode.None; // unlock the cursor
        Cursor.visible = true; // show the cursor to make it easier for the player to select dialogue
    }
}
