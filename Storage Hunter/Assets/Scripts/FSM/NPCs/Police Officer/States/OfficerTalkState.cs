using UnityEngine;

public class OfficerTalkState : OfficerBaseState
{
    public override void EnterState(OfficerStateManager officer)
    {
        Debug.Log("The Police Officer is now in the talk state");

        officer.isTalking = true;
    }

    public override void UpdateState(OfficerStateManager officer)
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            officer.isTalking = false;
            officer.switchState(officer.investigating);
        }
    }
}


