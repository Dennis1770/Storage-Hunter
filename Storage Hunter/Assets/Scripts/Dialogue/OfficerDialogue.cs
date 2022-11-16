using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficerDialogue : MonoBehaviour
{
    OfficerStateManager officerFSM;

    [Header("Ink JSON")] [SerializeField] private TextAsset inkJSON;

    private int i;

    private void Start()
    {
        i = 0;
        officerFSM = FindObjectOfType<OfficerStateManager>();
    }

    private void Update()
    {
        if(officerFSM.isTalking == true)
        {
            while (i < 1) 
            {
                i++;
                //Debug.Log(inkJSON.text);
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON); //ONLY CALL THIS ONCE AT THE START OF EACH CONVERSATION, otherwise it will endlessly restart the same conversation which is very bad
            }     
        }
        if(officerFSM.isTalking == false)
        {
            i = 0; //resetting this allows us to talk to the npc again
        }
    }
}
