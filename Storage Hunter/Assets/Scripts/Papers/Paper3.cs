using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paper3 : MonoBehaviour
{
    public GameObject paper3Stuff;
    public GameObject paper3canvas;
    public Renderer highlightRenderer;

    private void Start()
    {
        highlightRenderer = GetComponent<Renderer>();
    }
    private void OnMouseDown()
    {
        paper3Stuff.SetActive(false);
        paper3canvas.SetActive(true);
        Debug.Log("Clicking on Paper 3!");
    }


}
