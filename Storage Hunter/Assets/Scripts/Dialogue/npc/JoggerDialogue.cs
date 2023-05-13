using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoggerDialogue : MonoBehaviour
{
    //Michael
    JoggerStateManager joggerFSM;

    [Header("Ink JSON")][SerializeField] private TextAsset inkJSON;

    private bool isTalking;

    private void Start()
    {
        isTalking = false;
        joggerFSM = FindObjectOfType<JoggerStateManager>();
    }

    private void Update()
    {
        if (joggerFSM.isTalking == true)
        {
            if (isTalking == false)
            {
                isTalking = true;
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        if (joggerFSM.isTalking == false)
        {
            isTalking = false;
        }
    }
}
