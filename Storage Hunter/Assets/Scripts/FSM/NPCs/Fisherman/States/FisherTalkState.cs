using UnityEngine;

public class FisherTalkState : FisherBaseState
{

    public override void EnterState(FisherStateManager fisherman)
    {
        Debug.Log("The fisherman is now in the talk state");

        fisherman.isTalking = true;
    }

    public override void UpdateState(FisherStateManager fisherman)
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            fisherman.isTalking = false;
            fisherman.switchState(fisherman.fishing);
        }
    }
}
