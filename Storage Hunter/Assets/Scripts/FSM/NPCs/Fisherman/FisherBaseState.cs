using UnityEngine;
//Michael
public abstract class FisherBaseState
{
    public abstract void EnterState(FisherStateManager fisherman);
    public abstract void UpdateState(FisherStateManager fisherman);
}
