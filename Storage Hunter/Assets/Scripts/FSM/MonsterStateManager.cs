using UnityEngine;

/* This is the context for our finite state machine
 * this script creates instances of concrete states (idle, patrol and chase)
 * it determines which state is the active state at any given time
*/
public class MonsterStateManager : MonoBehaviour
{
    MonsterBaseState currentState;

    public MonsterIdleState idle = new MonsterIdleState();
    public MonsterPatrolState patrol = new MonsterPatrolState();
    public MonsterChaseState chase = new MonsterChaseState();

    private void Start()
    {
        currentState = idle; //this is the initial state
        currentState.EnterState(this); //pass in state specific context
    }

    private void Update()
    {
        currentState.UpdateState(this); //pass in state specific context
    }

    public void switchState(MonsterBaseState state)
    {
        currentState = state;
        state.EnterState(this); //pass in state specific context
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision); //pass in state specific context
    }
}
