using UnityEngine;
using UnityEngine.AI;
//Michael

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

    GameObject player;

    private playerMovement movement;

    //waypoints
    float minDistance = 6f;
    public Transform currentWaypoint;
    public int currentIndex;

    //hearing
    private float hearingDistance = 40f;

    //raycast
    private float sightDistance = 40f;

    //audio
    private AudioPlayer audioPlayer;

    public override void EnterState(MonsterStateManager monster)
    {
        Random.InitState(System.DateTime.Now.Millisecond); //set the seed for rng

        Debug.Log("Monster is now in the patrol state");

        monsterObject = GameObject.FindGameObjectWithTag("Monster");

        monsterAgent = monsterObject.GetComponent<NavMeshAgent>();

        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");

        audioPlayer = GameObject.Find("Main Camera").GetComponent<AudioPlayer>();

        currentWaypoint = waypoints[Random.Range(0, waypoints.Length)].transform;

        player = GameObject.FindGameObjectWithTag("Player");

        movement = GameObject.FindObjectOfType<playerMovement>();

        monsterAgent.speed = 8;

        monsterAgent.stoppingDistance = 1;
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        Debug.Log(waypoints);
        Debug.Log(currentWaypoint);
        Vector3 direction = currentWaypoint.transform.position;
        Vector3 playerDirection = (player.transform.position - monsterAgent.transform.position).normalized; //this doesn't need to be normalized 
        monsterAgent.SetDestination(direction);

        if (Vector3.Distance(currentWaypoint.transform.position, monsterAgent.transform.position) < minDistance)
        {
            //pick a random waypoint each time
            int number = Random.Range(0, waypoints.Length);
            currentIndex = number;
            currentWaypoint = waypoints[currentIndex].transform;
        }

        //Monster Eyesight
        RaycastHit hit;
        Ray sightRay = new Ray(monsterAgent.transform.position, playerDirection);
        //Debug.DrawRay(monsterAgent.transform.position, playerDirection/*monsterAgent.transform.TransformDirection(Vector3.forward)*/ * sightDistance, Color.blue);
        if (Physics.Raycast(sightRay, out hit, sightDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player has been spotted");
                audioPlayer.cuedSound = 1;
                audioPlayer.playAudio();
                monster.switchState(monster.chase);
            }
        }

        //Monster Hearing
        if (Vector3.Distance(monsterAgent.transform.position, player.transform.position) < hearingDistance)
        {
            Debug.Log($"noiseValue: {movement.noiseValue}");

            if (movement.noiseValue == 2)
            {
                Debug.Log("it heard you");
                audioPlayer.cuedSound = 1;
                audioPlayer.playAudio();
                monster.switchState(monster.chase);
            }
            else if (movement.noiseValue == 1)
            {
                Debug.Log("the monster can kinda hear you");
                audioPlayer.cuedSound = 0;
                audioPlayer.playAudio_oneShot();
                //play audio for to let the player know the monster is close?
            }
            else if (movement.noiseValue == 0)
            {
                Debug.Log("the monster doesn't hear you");

                audioPlayer.cuedSound = 0;
                audioPlayer.playAudio_oneShot();
            }
        }

    }
}
