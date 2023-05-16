using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherDialogue : MonoBehaviour
{
    //Michael
    FisherStateManager fisherFSM;
    [Header("Ink JSON")][SerializeField] private TextAsset[] inkJSON;

    private bool isDialoguing;
    private int count;
    [SerializeField] private int index; //use this to load the correct inkJSON file

    private void Start()
    {
        isDialoguing = false;
        fisherFSM = FindObjectOfType<FisherStateManager>();
    }

    private void Update()
    {
        if (fisherFSM.isTalking == true)
        {
            if (isDialoguing == false)
            {
                ChooseDialogue();
                count++;
                isDialoguing = true;
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON[index]);
            }
        }
        if (fisherFSM.isTalking == false)
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
