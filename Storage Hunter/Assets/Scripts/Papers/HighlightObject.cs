using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    //getting the mesh renderer of highlightObject
    public Renderer highlightObject;

    private void Start()
    {
        // Getting compnents to Renderer and assigning it to highlightObject and then disabling highlightObject mesh renderer at the start
        highlightObject = GetComponent<Renderer>();
        highlightObject.enabled = false;
    }


    private void OnMouseEnter()
    {
        //when mouse enters collider, enable mesh renderer so the highlight appears
        highlightObject.enabled = true;

    }

    private void OnMouseExit()
    {
        // when mouse exits collider, disable mesh renderer so the highlight disappears
        highlightObject.enabled = false;
    }


    public void disableHighlightObject()
    {
        highlightObject.enabled = false;
    }

}
