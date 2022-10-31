using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScene : MonoBehaviour
{

    private int sceneToContinue; //active save scene

    public void ReloadScene()
    {

        sceneToContinue = PlayerPrefs.GetInt("SavedScene"); //looks for the saved scene

        if(sceneToContinue != 0) //if active save scene != scene 0, load currently saved scene
        {

            SceneManager.LoadScene(sceneToContinue); //load current saved scene

        }
        else
        {

            return;

        }
        

    }


}
