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

    //waypoints
    float minDistance = 1f;
    public Transform currentWaypoint;
    public int currentIndex;

    //conecast
    private float capsuleRadius = 3f;
    private float capsuleDistance = 14f;
    private float capsuleAngle = 30f; //30 degrees

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

        //The single raycast doesn't allow the player to be seen through walls.  Consider using several of these instead of the capsulecast 
        /*
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
        */
        

        
        //calculate capsule raycast's start and end points
        Vector3 capsuleDirection = monsterAgent.transform.forward;
        Vector3 startPoint = monsterAgent.transform.position;
        Vector3 endPoint = monsterAgent.transform.position + direction * capsuleDistance;

        //calculate the axis of the capsule cast
        Vector3 capsuleAxis = Vector3.Cross(capsuleDirection, Vector3.up).normalized;

        //calculate the height and radius of the capsule
        float capsuleHeight = Mathf.Sin(capsuleAngle * Mathf.Deg2Rad) * capsuleDistance;
        Vector3 capsuleSize = new Vector3(capsuleRadius * 2f, capsuleHeight, capsuleRadius * 2f);

        //perform the capsule cast
        RaycastHit[] hits = Physics.CapsuleCastAll(startPoint, endPoint, capsuleRadius, capsuleDirection, capsuleDistance);

        foreach(RaycastHit hit in hits)
        {
            if(hit.collider.tag == "Player")
            {
                Debug.Log("Player has been spotted");
                monster.switchState(monster.chase);
                break;
            }
            
        }

        //draw the capsule cast
        Debug.DrawRay(startPoint, capsuleDirection * capsuleDistance, Color.blue);
        Debug.DrawRay(startPoint + capsuleAxis * capsuleRadius, capsuleDirection * capsuleDistance, Color.blue);
        Debug.DrawRay(startPoint - capsuleAxis * capsuleRadius, capsuleDirection * capsuleDistance, Color.blue);

        //I don't think drawwirecapsule exists in unity gizmos.. strange
        //Gizmos.DrawWireCapsule(startPoint + capsuleDirection * capsuleDistance * .5f, endPoint - capsuleDirection * capsuleDistance * .5f, capsuleRadius, capsuleAxis, Color.blue);
    
    }

    void OnDrawGizmos() 
    {
        Vector3 capsuleDirection = monsterAgent.transform.forward;
        Vector3 startPoint = monsterAgent.transform.position;
        Vector3 endPoint = monsterAgent.transform.position + capsuleDirection * capsuleDistance;
        Gizmos.DrawWireSphere(startPoint, capsuleRadius);
        Gizmos.DrawWireSphere(endPoint, capsuleRadius);
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
