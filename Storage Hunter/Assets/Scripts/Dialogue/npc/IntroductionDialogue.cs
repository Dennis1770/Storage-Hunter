using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionDialogue : MonoBehaviour
{
    IntroductionStateManager introFSM;
    IntroductionDialogue inkLoader; 
    [Header("Ink JSON")] public TextAsset[] inkJSON;

    [SerializeField] private int i;

    private void Start()
    {
        i = 0;
        Debug.Log("start: " +i);
        introFSM = FindObjectOfType<IntroductionStateManager>();
        inkLoader = GameObject.FindObjectOfType<IntroductionDialogue>();
    }

    private void Update()
    {
        if(introFSM.isActive == true)
        {
            if(i < 1)
            {
                i++;
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON[introFSM.storyIndex]);
            }
        }
        if(introFSM.isSleeping == true)
        {
            if(introFSM.storyIndex < inkLoader.inkJSON.Length -1)
            {
                i = 0;
                Debug.Log("sleep: " + i);
            }
            else return;
        }
    }
}
