using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (generator.SwitchLightsAllOn == true)
        {
            light.enabled = true;
        }
    }
}
