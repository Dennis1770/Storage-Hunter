using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Michael

public class DaleDialogue : MonoBehaviour
{
    DaleStateManager daleFSM;

    [Header("Ink JSON")][SerializeField] private TextAsset[] inkJSON;

    private bool isDialoguing; //use this to initialize the dialogue
    private int count; //use this to keep track of how many times the player has talked to dale
    private int clueComparison; //use this to change the dialogue after the player shows him their progress
    private int foundClues; //how many clues the player has found
    public bool hasClue1;
    public bool hasClue2;
    public bool hasClue3;
    [SerializeField] private int index; //use this to load the correct inkJSON file

    private void Start()
    {
        isDialoguing = false;
        index = 0;
        daleFSM = FindObjectOfType<DaleStateManager>();
    }

    private void Update()
    {
        if (daleFSM.isTalking == true)
        {
            if (isDialoguing == false)
            {
                ChooseDialogue();
                clueComparison = foundClues;
                count++;
                isDialoguing = true;
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON[index]);
            }
        }
        if (daleFSM.isTalking == false)
        {
            isDialoguing = false;
        }
    }

    private void ChooseDialogue()
    {
        //how many clues does the player have?
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

        Debug.Log($"we have {foundClues} clues and last time we talked to dale we had {clueComparison}");

        //what should dale say to the player?
        if (foundClues == 3)
        {
            if (foundClues == clueComparison)
            {
                index = 4; //in this case, we want the dialogue to remain the same
            }
            else
            {
                index = 4; //this is the first time we've shown dale 3 clues
            }
        }
        else if (foundClues == 2)
        {
            if (foundClues == clueComparison)
            {
                index = 1;
            }
            else
            {
                index = 3; //this is the first time we've shown dale 2 clues
            }
        }
        else if (foundClues == 1)
        {
            if (foundClues == clueComparison)
            {
                index = 1;
            }
            else
            {
                index = 2; //this is the first time we've shown dale 1 clue
            }
        }
        else if (count == 0) //we haven't found any clues
        {
            index = 0; //we haven't talked to dale yet
        }
        else index = 1; //we don't have any clues yet and we've talked to dale at least one time already
    }
}
