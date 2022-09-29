using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    public GameObject on; //on sphere
    public GameObject off; //off sphere
    private bool isON; //is the flashlight on
    
    
    // Start is called before the first frame update
    void Start()
    {

        on.SetActive(false); //flashlight isnt on at start
        off.SetActive(true); //flashlight is off at start
        isON = false; //flashlight isn't on

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.F)) //if the F key is pressed down, turn on/off flash light
        {

            if(isON == true) //if isON = true, the flashlight is off
            {

                on.SetActive(false);
                off.SetActive(true);


            }

            if (!isON) //if isON doesn't = true, the flashlight is on
            {

                on.SetActive(true);
                off.SetActive(false);


            }

            isON = !isON; // isOn = not isOn

        }



    }
}
