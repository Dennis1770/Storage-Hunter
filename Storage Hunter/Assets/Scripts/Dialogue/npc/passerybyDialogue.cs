using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passerybyDialogue : MonoBehaviour
{
    //Michael
    GenericStateManager passerbyFSM
    ;
    [Header("Ink JSON")][SerializeField] private TextAsset[] inkJSON;

    private bool isDialoguing;
    private int count;
    [SerializeField] private int index; //use this to load the correct inkJSON file

    private void Start()
    {
        isDialoguing = false;
        passerbyFSM = GetComponentInParent<GenericStateManager>();
    }

    private void Update()
    {
        if (passerbyFSM
        .isTalking == true)
        {
            if (isDialoguing == false)
            {
                ChooseDialogue();
                count++;
                isDialoguing = true;
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON[index]);
            }
        }
        if (passerbyFSM
        .isTalking == false)
        {
            isDialoguing = false;
        }
    }

    private void ChooseDialogue()
    {
        if (count == 0)
        {
            index = 0;
        }
        else
        {
            index = 1;
        }
    }
}
