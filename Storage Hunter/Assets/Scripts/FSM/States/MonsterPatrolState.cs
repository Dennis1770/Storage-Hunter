using UnityEngine;

/*This is one of the concrete states
 * it is self-contained
 * can have its own unique properties and methods
*/
public class MonsterPatrolState : MonsterBaseState
{
    GameObject monster;
    GameObject monsterGameObject;
    GameObject[] waypoints; //waypoints for the monster to patrol between
    //Transform[] wpTransforms; //we need the transforms of each waypoint

    private float minDistance = 1f;
    private float moveSpeed = 5f;
    public Transform currentWaypoint;
    public int currentIndex;


    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("Monster is now in the patrol state");
        monsterGameObject = GameObject.FindGameObjectWithTag("monster");
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        
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
        Vector3 direction = currentWaypoint.transform.position - monsterGameObject.transform.position;
        Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
        monsterGameObject.transform.position += moveVector;

        if(Vector3.Distance(currentWaypoint.transform.position, monsterGameObject.transform.position) < minDistance)
        {
            /*
            ++currentIndex;
            if(currentIndex > waypoints.Length - 1)
            {
                currentIndex = 0;
            }

            currentWaypoint = waypoints[currentIndex].transform;
            */

            int number = Random.Range(0, waypoints.Length);
            currentIndex = number;
            Debug.Log(number);
            currentWaypoint = waypoints[currentIndex].transform;
        }
        
    }

    public override void OnCollisionEnter(MonsterStateManager monster)
    {
        //monster.switchState(monster.chase);
    }
}
