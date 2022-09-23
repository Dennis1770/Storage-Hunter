using UnityEngine;

public class MonsterStateManager : MonoBehaviour
{
    MonsterBaseState currentState;

    public MonsterIdleState idle = new MonsterIdleState();
    public MonsterPatrolState patrol = new MonsterPatrolState();
    public MonsterHuntState hunt = new MonsterHuntState();
    public MonsterChaseState chase = new MonsterChaseState();

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
