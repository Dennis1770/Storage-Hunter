using UnityEngine;

public abstract class SoccerPlayerBaseState : MonoBehaviour
{
    public abstract void EnterState(SoccerPlayerStateManager soccer);

    public abstract void UpdateState(SoccerPlayerStateManager soccer);
}
