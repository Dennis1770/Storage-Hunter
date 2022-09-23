using UnityEngine;

public class MonsterStateManager : MonoBehaviour
{
    MonsterBaseState currentState;

    public MonsterIdleState idle;
    public MonsterPatrolState patrol;
    public MonsterHuntState hunt;
    public MonsterChaseState chase;

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

    private void switchState(MonsterBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
