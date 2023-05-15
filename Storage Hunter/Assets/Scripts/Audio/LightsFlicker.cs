using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls when lights flicker On/Off and handles SFX depending if the light is On/Off

public class LightsFlicker : MonoBehaviour
{

    // Insert Light in Unity
    public Light light01;

    // Audio files for Light
    public AudioSource lightFlickerSFX;
    public AudioSource lightHummingSFX;

    // Light Settings
    public float minTime;
    public float maxTime;
    public float timer;


    void Start()
    {
        // a timer that selects a random number between the min and max time
        timer = Random.Range(minTime, maxTime);
    }



    // Update is called once per frame
    void Update()
    {
        // constantly checks this function
        LightsFlickering();
    }

    void LightsFlickering()
    {
        // ticks the timer down
        if (timer > 0)
            timer -= Time.deltaTime;


        // if timer reaches 0 or less than 0, 
        if (timer <= 0)
        {
            // switches light enable to true/false
            light01.enabled = !light01.enabled;
            // calls LightsHumming() method
            LightsHumming();

            // selects a number between the min/max values
            timer = Random.Range(minTime, maxTime);
            // play SFX
            lightFlickerSFX.Play();
        }



    }

    void LightsHumming()
    {
        // If Light is enabled, play lightHummingSFX, if not enabled, stop SFX
        if (light01.enabled == true)
        {
            lightHummingSFX.Play();
        }
        else
        {
            lightHummingSFX.Stop();
        }

    }

}
