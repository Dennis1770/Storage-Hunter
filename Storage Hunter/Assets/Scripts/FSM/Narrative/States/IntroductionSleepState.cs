using UnityEngine;

public class IntroductionSleepState : IntroductionBaseState
{
    IntroductionStateManager introFSM;
    IntroductionDialogue inkLoader;

    public override void EnterState(IntroductionStateManager introduction)
    {        
        Debug.Log("Introduction is in the sleep state");
        introduction.isSleeping = true;

        introFSM = GameObject.FindObjectOfType<IntroductionStateManager>();
        inkLoader = GameObject.FindObjectOfType<IntroductionDialogue>();
    }

    public override void UpdateState(IntroductionStateManager introduction)
    {
        if(!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            //IntroductionStateManager introFSM = GameObject.FindObjectOfType<IntroductionStateManager>();
            //IntroductionDialogue inkLoader = GameObject.FindObjectOfType<IntroductionDialogue>();
            //check the story index, compare it to inkJSON.Length to see if there's more content
            if(introFSM.storyIndex < inkLoader.inkJSON.Length -1)
            {
                introduction.isSleeping = false;
                introduction.switchState(introduction.active);
            } 
        }
    }
}
