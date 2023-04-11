using UnityEngine;

public class IntroductionSleepState : IntroductionBaseState
{
    public override void EnterState(IntroductionStateManager introduction)
    {
        Debug.Log("Introduction is in the sleep state");
    }

    public override void UpdateState(IntroductionStateManager introduction)
    {
        if(!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            introduction.isSleeping = false;
            introduction.switchState(introduction.active);
        }
    }
}
