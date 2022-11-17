using UnityEngine;

public abstract class OfficerBaseState 
{
    public abstract void EnterState(OfficerStateManager officer);

    public abstract void UpdateState(OfficerStateManager officer);
}
