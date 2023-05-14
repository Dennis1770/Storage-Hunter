using UnityEngine;
//Michael
public class KidTalkState : KidBaseState
{
    public override void EnterState(KidStateManager kid)
    {
        Debug.Log("The kid is now in the talk state");

        kid.isTalking = true;
    }

    public override void UpdateState(KidStateManager kid)
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            kid.isTalking = false;
            kid.switchState(kid.playing);
        }
    }
}
