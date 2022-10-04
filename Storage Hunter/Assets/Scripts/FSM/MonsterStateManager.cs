using UnityEngine;

/* This is the context for our finite state machine
 * this script creates instances of concrete states (idle, patrol, hunt, and chase)
 * it determines which state is the active state at any given time
*/
public class MonsterStateManager : MonoBehaviour
{
    MonsterBaseState currentState;

    public MonsterIdleState idle = new MonsterIdleState();
    public MonsterPatrolState patrol = new MonsterPatrolState();
    public MonsterHuntState hunt = new MonsterHuntState();
    public MonsterChaseState chase = new MonsterChaseState();

    /*
    //patrol state
    [Tooltip("In patrol state: how close the agent will get to each waypoint")] public float minDistance;
    [Tooltip("How fast the agent will move")] public float moveSpeed;
    [Tooltip("In patrol state: where the agent is currently going")] public Transform currentWaypoint;
    [HideInInspector] public int currentIndex;
    */

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

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }
}
