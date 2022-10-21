using UnityEngine;

public abstract class JoggerBaseState
{
    public abstract void EnterState(JoggerStateManager jogger);

    public abstract void UpdateState(JoggerStateManager jogger);

    public abstract void OnCollisionEnter(JoggerStateManager jogger, Collision collision); //Rather than doing collisions, we should use the item interaction to start talking to npcs
}
