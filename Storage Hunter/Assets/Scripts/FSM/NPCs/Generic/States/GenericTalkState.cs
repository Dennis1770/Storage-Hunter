using UnityEngine;
//Michael

public class GenericTalkState : GenericBaseState
{
    public override void EnterState(GenericStateManager generic)
    {
        generic.isTalking = true;
    }

    public override void UpdateState(GenericStateManager generic, GameObject holdingObject)
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            generic.isTalking = false;
            generic.switchState(generic.idle);
        }
    }
}
