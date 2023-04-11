using UnityEngine;

public class IntroductionStateManager : MonoBehaviour
{
    IntroductionBaseState currentState;

    public IntroductionSleepState sleeping = new IntroductionSleepState();
    public IntroductionActiveState active = new IntroductionActiveState();
    public bool isSleeping = false;
    public bool isActive = false;

    private void Start()
    {
        currentState = sleeping;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void switchState(IntroductionBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
