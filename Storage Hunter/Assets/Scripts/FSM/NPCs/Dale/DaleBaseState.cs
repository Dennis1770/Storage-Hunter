using UnityEngine;

public abstract class DaleBaseState
{
    public abstract void EnterState(DaleStateManager dale);
    public abstract void UpdateState(DaleStateManager dale);
}
