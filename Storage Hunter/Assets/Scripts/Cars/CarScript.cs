using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float[] speeds;
    public float speed;
    
    void Start()
    {
        speed = speeds[Random.Range(0, speeds.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
