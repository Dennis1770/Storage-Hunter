using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionDialogue : MonoBehaviour
{
    IntroductionStateManager introFSM;

    [Header("Ink JSON")] [SerializeField] private TextAsset inkJSON;

    private int i;

    private void Start()
    {
        i = 0;
        introFSM = FindObjectOfType<IntroductionStateManager>();
    }

    private void Update()
    {
        if(introFSM.isActive == true)
        {
            if(i < 1)
            {
                i++;
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        if(introFSM.isSleeping == false)
        {
            return;
        }
    }
}
