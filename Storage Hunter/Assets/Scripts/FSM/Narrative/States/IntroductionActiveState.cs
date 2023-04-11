using UnityEngine;

public class IntroductionActiveState : IntroductionBaseState
{
    public override void EnterState(IntroductionStateManager introduction)
    {
        Debug.Log("Introduction is now in the active state");
        introduction.isActive = true;
    }

    public override void UpdateState(IntroductionStateManager introduction)
    {
        if(!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
    }
}
