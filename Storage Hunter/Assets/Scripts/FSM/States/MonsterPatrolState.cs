using UnityEngine;

/*This is one of the concrete states
 * it is self-contained
 * can have its own unique properties and methods
*/
public class MonsterPatrolState : MonsterBaseState
{
    GameObject monster;
    GameObject[] waypoints; //waypoints for the monster to patrol between
    Transform[] wpTransforms; //we need the transforms of each waypoint

    public Transform currentWaypoint;
    public int currentIndex;

    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("Monster is now in the patrol state");
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        wpTransforms = new Transform[waypoints.Length];

        for(int i=0; i < waypoints.Length; i++)
        {
            //get the transform values of each waypoint in our array
            wpTransforms[i] = waypoints[i].transform;
        }
    }

    public override void UpdateState(MonsterStateManager monster)
    {

    }

    public override void OnCollisionEnter(MonsterStateManager monster)
    {
        //monster.switchState(monster.chase);
    }
}
