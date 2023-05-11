using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoggerDialogue : MonoBehaviour
{
    //Michael
    JoggerStateManager joggerFSM;

    [Header("Ink JSON")][SerializeField] private TextAsset inkJSON;

    private int i;

    private void Start()
    {
        i = 0;
        joggerFSM = FindObjectOfType<JoggerStateManager>();
    }

    private void Update()
    {
        if (joggerFSM.isTalking == true)
        {
            if (i < 1)
            {
                i++;
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        if (joggerFSM.isTalking == false)
        {
            i = 0;
        }
    }
}
