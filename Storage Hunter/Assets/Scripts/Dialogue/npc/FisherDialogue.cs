using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherDialogue : MonoBehaviour
{
    FisherStateManager fisherFSM;
    [Header("Ink JSON")] [SerializeField] private TextAsset inkJSON;

    private int i;

    private void Start()
    {
        i = 0;
        fisherFSM = FindObjectOfType<FisherStateManager>();
    }

    private void Update()
    {
        if (fisherFSM.isTalking == true)
        {
            if (i < 1)
            {
                i++;
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        if (fisherFSM.isTalking == false)
        {
            i = 0;
        }
    }
}
