using UnityEngine;
using UnityEngine.AI;

/*This is one of the concrete states
 * it is self-contained
 * can have its own unique properties and methods
*/
public class MonsterPatrolState : MonsterBaseState
{
    GameObject monster;

    GameObject monsterObject;

    NavMeshAgent monsterAgent; //the monster is a navmesh agent, used for A* pathfinding

    GameObject[] waypoints; //waypoints for the monster to patrol between

    float minDistance = 1f;
    public Transform currentWaypoint;
    public int currentIndex;

    public override void EnterState(MonsterStateManager monster)
    {
        Random.InitState(System.DateTime.Now.Millisecond); //set the seed for rng

        Debug.Log("Monster is now in the patrol state");

        monsterObject = GameObject.FindGameObjectWithTag("Monster");

        monsterAgent = monsterObject.GetComponent<NavMeshAgent>();

        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");

        currentWaypoint = waypoints[Random.Range(0, waypoints.Length)].transform;
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        Vector3 direction = currentWaypoint.transform.position;
        monsterAgent.SetDestination(direction);
        //Debug.Log(currentWaypoint);

        if(Vector3.Distance(currentWaypoint.transform.position, monsterAgent.transform.position) < minDistance)
        {
            //pick a random waypoint each time
            int number = Random.Range(0, waypoints.Length);
            currentIndex = number;
            currentWaypoint = waypoints[currentIndex].transform;
        }

        RaycastHit hit;
        Ray sightRay = new Ray(monsterAgent.transform.position, monsterAgent.transform.TransformDirection(Vector3.forward));
        Debug.DrawRay(monsterAgent.transform.position, monsterAgent.transform.TransformDirection(Vector3.forward) * 14f, Color.blue);
        if (Physics.Raycast(sightRay, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                Debug.Log("Player has been spotted");
                monster.switchState(monster.chase);
            }
            //else Debug.Log("Nothing spotted");
        }
    }

    public override void OnCollisionEnter(MonsterStateManager monster, Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            Debug.Log("game over"); //the player has been caught
        }
    }
}
