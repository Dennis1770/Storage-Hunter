using UnityEngine;

public class JoggerTalkState : JoggerBaseState
{
    public override void EnterState(JoggerStateManager jogger)
    {
        Debug.Log("Jogger is now in the talk state");

        jogger.isTalking = true;
    }

    public override void UpdateState(JoggerStateManager jogger)
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            jogger.isTalking = false;
            jogger.switchState(jogger.jogging);
        }
    }
}
