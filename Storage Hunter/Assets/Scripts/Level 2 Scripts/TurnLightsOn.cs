using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scripted by Aaron Lee
public class TurnLightsOn : MonoBehaviour
{

    public Generator generator;

    Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        TurningLightsOn();
    }


    void TurningLightsOn()
    {
        // turn light on if all switches are on and player presses generator switch
        if (generator.SwitchLightsAllOn == true)
        {
            light.enabled = true;
        }
    }
}
