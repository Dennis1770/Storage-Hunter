using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaleDialogue : MonoBehaviour
{
    DaleStateManager daleFSM;

    [Header("Ink JSON")][SerializeField] private TextAsset[] inkJSON;

    private int i;
    [SerializeField] private bool hasClue1;
    [SerializeField] private bool hasClue2;
    [SerializeField] private bool hasClue3;
    [SerializeField] private int index;

    private void Start()
    {
        i = 0;
        index = 0;
        daleFSM = FindObjectOfType<DaleStateManager>();
    }

    private void Update()
    {
        ChooseDialogue();
        if (daleFSM.isTalking == true)
        {
            if (i < 1)
            {
                i++;
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON[index]);
            }
        }
        if (daleFSM.isTalking == false)
        {
            i = 0;
        }
    }

    private void ChooseDialogue()
    {
        if (hasClue1 == true && hasClue2 == true && hasClue3 == true)
        {
            index = 2;
            //tell the player about heading to the dock
        }
        else if (hasClue1 == true || hasClue2 == true || hasClue3 == true)
        {
            index = 1;
        }
        else
        {
            index = 0;
        }
    }
}
