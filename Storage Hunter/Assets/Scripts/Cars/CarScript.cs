using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    //Michael
    [Tooltip("One speed is randomly selected")][SerializeField] private float[] speeds;
    private float speed;
    [Tooltip("Set true if the car is parked")][SerializeField] private bool isParked;
    private Color[] colors = new Color[]
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow,
        Color.magenta,
        Color.cyan,
        new Color(1f, 0.41f, 0.71f) //pink
    };


    void Start()
    {
        Color randomColor = colors[Random.Range(0, colors.Length)];
        Transform carBody = transform.Find("MainCarBody");
        if (carBody != null)
        {
            Renderer renderer = carBody.GetComponent<Renderer>();
            renderer.material.color = randomColor;
        }

        if (isParked) speed = 0;
        else speed = speeds[Random.Range(0, speeds.Length)];
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
