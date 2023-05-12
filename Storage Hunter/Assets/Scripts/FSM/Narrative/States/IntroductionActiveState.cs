using UnityEngine;
//Michael
public class IntroductionActiveState : IntroductionBaseState
{
    public override void EnterState(IntroductionStateManager introduction)
    {
        Debug.Log("Introduction is now in the active state");

        IntroductionStateManager introFSM = GameObject.FindObjectOfType<IntroductionStateManager>();

        if (introduction.isActive == false)
        {
            introduction.isActive = true;
            introFSM.storyIndex += 1;
        }

    }

    public override void UpdateState(IntroductionStateManager introduction)
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            introduction.isActive = false;
            introduction.switchState(introduction.sleeping);
        }
    }
}
