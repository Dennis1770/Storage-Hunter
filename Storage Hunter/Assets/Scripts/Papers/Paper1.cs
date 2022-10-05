using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paper1 : MonoBehaviour
{
    public GameObject paper1Stuff;
    public GameObject paper1canvas;
    public Renderer highlightRenderer;

    private void Start()
    {
        highlightRenderer = GetComponent<Renderer>();
    }
    private void OnMouseDown()
    {
        paper1Stuff.SetActive(false);
        paper1canvas.SetActive(true);
        Debug.Log("Clicking on Paper 1!");
    }

}
