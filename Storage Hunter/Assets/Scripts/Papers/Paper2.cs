using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paper2 : MonoBehaviour
{
    public GameObject paper2Stuff;
    public GameObject paper2canvas;
    public Renderer highlightRenderer;

    private void Start()
    {
        highlightRenderer = GetComponent<Renderer>();
    }
    private void OnMouseDown()
    {
        paper2Stuff.SetActive(false);
        paper2canvas.SetActive(true);
        Debug.Log("Clicking on Paper 2!");
    }


}
