using UnityEngine;

public abstract class OfficerBaseState 
{
    public abstract void EnterState(OfficerStateManager officer);

    public abstract void UpdateState(OfficerStateManager officer);

    //public abstract void OnCollisionEnter(OfficerStateManager officer, Collision collision);
}
