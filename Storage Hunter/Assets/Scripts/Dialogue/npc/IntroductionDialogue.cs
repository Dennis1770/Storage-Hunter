using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionDialogue : MonoBehaviour
{
    //Michael
    IntroductionStateManager introFSM;
    IntroductionDialogue inkLoader;
    [Header("Ink JSON")] public TextAsset[] inkJSON;

    [SerializeField] private bool hasStarted;

    private void Start()
    {
        hasStarted = false;
        introFSM = FindObjectOfType<IntroductionStateManager>();
        //inkLoader = GameObject.FindObjectOfType<IntroductionDialogue>();
        inkLoader = this;
    }

    private void Update()
    {
        if (introFSM.isActive == true)
        {
            if (hasStarted == false) //if we call EnterDialogueMode every frame, it won't work
            {
                hasStarted = true;
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON[introFSM.storyIndex]);
            }
        }
        if (introFSM.isSleeping == true)
        {
            hasStarted = false; //reset
            /*
            if (introFSM.storyIndex < inkLoader.inkJSON.Length - 1)
            {
               
            }
            else return;
            */
        }
    }
}
