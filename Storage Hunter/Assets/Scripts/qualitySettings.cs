using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qualitySettings : MonoBehaviour
{
    
    public void SetQuality(int qualityIndex)
    {

        QualitySettings.SetQualityLevel(qualityIndex, false); //chooses from project settings
        Debug.Log("Changed Settings");

    }

}
