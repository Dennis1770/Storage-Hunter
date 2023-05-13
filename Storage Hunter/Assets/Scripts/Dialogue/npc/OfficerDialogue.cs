using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficerDialogue : MonoBehaviour
{
    //Michael
    OfficerStateManager officerFSM;

    [Header("Ink JSON")][SerializeField] private TextAsset inkJSON;

    private bool isDialoguing;

    private void Start()
    {
        isDialoguing = false;
        officerFSM = FindObjectOfType<OfficerStateManager>();
    }

    private void Update()
    {
        if (officerFSM.isTalking == true)
        {
            if (isDialoguing == false)
            {
                isDialoguing = true;
                //Debug.Log(inkJSON.text);
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON); //ONLY CALL THIS ONCE AT THE START OF EACH CONVERSATION, otherwise it will endlessly restart the same conversation which is very bad
            }
        }
        if (officerFSM.isTalking == false)
        {
            isDialoguing = false; //resetting this allows us to talk to the npc again
        }
    }

}
