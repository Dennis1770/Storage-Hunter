using UnityEngine;

public abstract class JoggerBaseState
{
    public abstract void EnterState(JoggerStateManager jogger);

    public abstract void UpdateState(JoggerStateManager jogger);
}
