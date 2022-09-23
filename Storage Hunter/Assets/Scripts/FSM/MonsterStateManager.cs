using UnityEngine;

public class MonsterStateManager : MonoBehaviour
{
    MonsterBaseState currentState;

    MonsterIdleState idle = new MonsterIdleState();
    MonsterPatrolState patrol = new MonsterPatrolState();
    MonsterHuntState hunt = new MonsterHuntState();
    MonsterChaseState chase = new MonsterChaseState();

    private void Start()
    {
        //initial state
        currentState = idle;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void switchState(MonsterBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
