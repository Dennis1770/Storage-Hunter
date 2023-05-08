using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaleDialogue : MonoBehaviour
{
    DaleStateManager daleFSM;

    [Header("Ink JSON")][SerializeField] private TextAsset inkJSON;

    private int i;

    private void Start()
    {
        i = 0;
        daleFSM = FindObjectOfType<DaleStateManager>();
    }

    private void Update()
    {
        if (daleFSM.isTalking == true)
        {
            if (i < 1)
            {
                i++;
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        if (daleFSM.isTalking == false)
        {
            i = 0;
        }
    }
}
