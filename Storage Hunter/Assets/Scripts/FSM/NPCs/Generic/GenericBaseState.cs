using UnityEngine;
//Michael
public abstract class GenericBaseState
{
    public abstract void EnterState(GenericStateManager generic);
    public abstract void UpdateState(GenericStateManager generic, GameObject holdingObject);
}
