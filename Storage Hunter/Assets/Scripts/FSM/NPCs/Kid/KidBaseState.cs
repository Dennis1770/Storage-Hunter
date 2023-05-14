using UnityEngine;
//Michael
public abstract class KidBaseState
{
    public abstract void EnterState(KidStateManager kid);

    public abstract void UpdateState(KidStateManager kid);
}
