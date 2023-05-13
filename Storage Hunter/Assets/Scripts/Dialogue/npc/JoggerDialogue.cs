using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoggerDialogue : MonoBehaviour
{
    //Michael
    JoggerStateManager joggerFSM;

    [Header("Ink JSON")][SerializeField] private TextAsset inkJSON;

    private bool isDialoguing;

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
                isDialoguing = true;
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        if (joggerFSM.isTalking == false)
        {
            isDialoguing = false;
        }
    }
}
