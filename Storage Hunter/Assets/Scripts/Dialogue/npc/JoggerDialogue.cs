using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Michael
public class JoggerDialogue : MonoBehaviour
{
    JoggerStateManager joggerFSM;

    [Header("Ink JSON")][SerializeField] private TextAsset[] inkJSON;

    private bool isDialoguing; //use this to initialize the dialogue
    private int count; //keep track of how many times we talk to this npc
    private int index;

    private void Start()
    {
        isDialoguing = false;
        joggerFSM = FindObjectOfType<JoggerStateManager>();
    }

    private void Update()
    {
        if (joggerFSM.isTalking == true)
        {
            if (isDialoguing == false)
            {
                ChooseDialogue();
                count++;
                isDialoguing = true;
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON[index]);
            }
        }
        if (joggerFSM.isTalking == false)
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
        else index = 1;
    }
}
