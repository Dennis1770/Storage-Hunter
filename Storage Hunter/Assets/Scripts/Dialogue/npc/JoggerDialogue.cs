using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoggerDialogue : MonoBehaviour
{
    JoggerStateManager joggerFSM;

    [Header("Ink JSON")] [SerializeField] private TextAsset inkJSON;

    private void Start()
    {
        joggerFSM = FindObjectOfType<JoggerStateManager>();
    }

    private void Update()
    {
        if(joggerFSM.isTalking == true)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
    }
}
