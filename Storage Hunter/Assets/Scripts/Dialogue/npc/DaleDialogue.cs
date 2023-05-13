using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaleDialogue : MonoBehaviour
{
    //Michael
    DaleStateManager daleFSM;

    [Header("Ink JSON")][SerializeField] private TextAsset[] inkJSON;

    private bool isTalking;
    private int count; //use this to change the dialogue after the player has talked to Dale once
    private int foundClues; //how many of the three clues the player has found
    public bool hasClue1;
    public bool hasClue2;
    public bool hasClue3;
    [SerializeField] private int index;

    private void Start()
    {
        isTalking = false;
        index = 0;
        daleFSM = FindObjectOfType<DaleStateManager>();
    }

    private void Update()
    {
        ChooseDialogue();
        if (daleFSM.isTalking == true)
        {
            if (isTalking == false)
            {
                isTalking = true;
                count++;
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON[index]);
            }
        }
        if (daleFSM.isTalking == false)
        {
            isTalking = false;
        }
    }

    private void ChooseDialogue()
    {
        foundClues = 0; //reset each time we check
        if (hasClue1 == true)
        {
            foundClues += 1;
        }
        if (hasClue2 == true)
        {
            foundClues += 1;
        }
        if (hasClue3 == true)
        {
            foundClues += 1;
        }

        if (foundClues == 3)
        {
            index = 4;
        }
        else if (foundClues == 2)
        {
            index = 3;
        }
        else if (foundClues == 1)
        {
            index = 2;
        }
        else if (count == 0)
        {
            index = 0;
        }
        else index = 1;
    }
}
