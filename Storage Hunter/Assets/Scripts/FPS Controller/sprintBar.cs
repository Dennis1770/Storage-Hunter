using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sprintBar : MonoBehaviour
{

   //Script written by Andrew
    
    private float startSprint = 100; //bar starting value
    public float currentSprint; //bar current value
    public Slider staminaBar; //sprint bar component
    
    // Start is called before the first frame update
    void Start()
    {

        currentSprint = startSprint; //current sprint = starting sprint

    }

    // Update is called once per frame
    void Update()
    {

        currentSprint += 0.1f; //stamina recharges at a rate of .1
        staminaBar.value = currentSprint; //the value of the stamina bar is equal to the current sprint

        if(currentSprint >= 100) //if the current sprint is >= 100, the current sprint is maxed out at 100
        {

            currentSprint = 100;

        }

    }

    public void TakeStamina(float amount)
    {

        currentSprint -= amount; //the current sprint loses amount during sprint
        staminaBar.value = currentSprint; //the value of the stamina bar is equal to the current sprint

    }

}
