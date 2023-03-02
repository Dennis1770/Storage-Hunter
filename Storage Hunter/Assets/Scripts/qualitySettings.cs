using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class qualitySettings : MonoBehaviour
{

    public RenderPipelineAsset[] qualityLevels; //array for URP render pipeline settings
    public TMP_Dropdown dropdown; //text mesh pro dropdown menu
    
    // Start is called before the first frame update
    void Start()
    {

        dropdown.value = QualitySettings.GetQualityLevel(); //default quality level

    }

    public void ChnageLevel(int value)
    {

        QualitySettings.SetQualityLevel(value); //set quality to selected option
        QualitySettings.renderPipeline = qualityLevels[value]; //select different qualuty from list
    }

}
