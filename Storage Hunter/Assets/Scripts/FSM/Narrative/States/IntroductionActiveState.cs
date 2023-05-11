using UnityEngine;
//Michael
public class IntroductionActiveState : IntroductionBaseState
{
    public override void EnterState(IntroductionStateManager introduction)
    {
        Debug.Log("Introduction is now in the active state");
        introduction.isActive = true;
        IntroductionStateManager introFSM = GameObject.FindObjectOfType<IntroductionStateManager>();
        introFSM.storyIndex += 1;
    }

    public override void UpdateState(IntroductionStateManager introduction)
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            introduction.switchState(introduction.sleeping);
        }
    }
}
