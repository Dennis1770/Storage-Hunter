using UnityEngine;

public class DaleTalkState : DaleBaseState
{
    public override void EnterState(DaleStateManager dale)
    {
        Debug.Log("Dale is now in the talk state");
        dale.isTalking = true;
    }

    public override void UpdateState(DaleStateManager dale)
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            dale.isTalking = false;
            dale.switchState(dale.following);
        }
    }
}
