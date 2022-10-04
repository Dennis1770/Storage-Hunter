using UnityEngine;
using UnityEngine.AI;

/*This is one of the concrete states
 * it is self-contained
 * can have its own unique properties and methods
*/
public class MonsterPatrolState : MonsterBaseState
{
    GameObject monster;

    //GameObject monsterGameObject;

    NavMeshAgent agent;

    //MonsterStateManager stateManager;

    GameObject[] waypoints; //waypoints for the monster to patrol between


    private float minDistance = 1f;
    //private float moveSpeed = 5f;
    public Transform currentWaypoint;
    public int currentIndex;


    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("Monster is now in the patrol state");

        agent = GameObject.FindObjectOfType<NavMeshAgent>();

        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        
        /*
        for (int i=0; i< waypoints.Length; i++)
        {
            Debug.Log(waypoints[i].transform);
        }
        */

        currentWaypoint = waypoints[0].transform;
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        /*
        Vector3 direction = currentWaypoint.transform.position - agent.transform.position;
        Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
        agent.transform.position += moveVector; //walk to the waypoint
        agent.transform.LookAt(currentWaypoint.transform); //the monster should face where it's walking
        */

        Vector3 direction = currentWaypoint.transform.position;
        agent.SetDestination(direction);
        Debug.Log(currentWaypoint);

        if(Vector3.Distance(currentWaypoint.transform.position, agent.transform.position) < minDistance)
        {
            /*
            //go to every waypoint in order

            ++currentIndex;
            if(currentIndex > waypoints.Length - 1)
            {
                currentIndex = 0;
            }

            currentWaypoint = waypoints[currentIndex].transform;
            */

            //pick a random waypoint each time
            int number = Random.Range(0, waypoints.Length);
            currentIndex = number;
            currentWaypoint = waypoints[currentIndex].transform;
        }
        
    }

    public override void OnCollisionEnter(MonsterStateManager monster, Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            Debug.Log("game over");
            //the player has been caught
        }
    }
}
