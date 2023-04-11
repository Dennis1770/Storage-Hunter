using UnityEngine;

public abstract class IntroductionBaseState
{
    public abstract void EnterState(IntroductionStateManager introduction);
    public abstract void UpdateState(IntroductionStateManager introduction);
}
