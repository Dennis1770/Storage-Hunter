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

    GameObject player;

    private playerMovement movement;

    //waypoints
    float minDistance = 1f;
    public Transform currentWaypoint;
    public int currentIndex;

    //conecast
    private float capsuleRadius = 3f;
    private float capsuleDistance = 10f;
    private float capsuleAngle = 30f; //30 degrees

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
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        Vector3 direction = currentWaypoint.transform.position;
        Vector3 playerDirection = (player.transform.position - monsterAgent.transform.position).normalized;
        monsterAgent.SetDestination(direction);
        //Debug.Log(currentWaypoint);

        if(Vector3.Distance(currentWaypoint.transform.position, monsterAgent.transform.position) < minDistance)
        {
            //pick a random waypoint each time
            int number = Random.Range(0, waypoints.Length);
            currentIndex = number;
            currentWaypoint = waypoints[currentIndex].transform;
        }

        //Monster Eyesight
        RaycastHit hit;
        Ray sightRay = new Ray(monsterAgent.transform.position, playerDirection/*monsterAgent.transform.TransformDirection(Vector3.forward)*/);
        Debug.DrawRay(monsterAgent.transform.position, playerDirection/*monsterAgent.transform.TransformDirection(Vector3.forward)*/ * 14f, Color.blue);
        if (Physics.Raycast(sightRay, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                Debug.Log("Player has been spotted");
                audioPlayer.cuedSound = 1;
                audioPlayer.playAudio();
                monster.switchState(monster.chase);
            }
        }
        

        //Monster Hearing

        //calculate capsule raycast's start and end points
        Vector3 capsuleDirection = /*monsterAgent.transform.forward*/ playerDirection;
        Vector3 startPoint = monsterAgent.transform.position;
        Vector3 endPoint = monsterAgent.transform.position + /*direction*/ player.transform.position * capsuleDistance;
        
        //calculate the axis of the capsule cast
        Vector3 capsuleAxis = Vector3.Cross(capsuleDirection, Vector3.up).normalized;

        //calculate the height and radius of the capsule
        float capsuleHeight = Mathf.Sin(capsuleAngle * Mathf.Deg2Rad) * capsuleDistance;
        Vector3 capsuleSize = new Vector3(capsuleRadius * 2f, capsuleHeight, capsuleRadius * 2f);

        //perform the capsule cast
        RaycastHit[] hits = Physics.CapsuleCastAll(startPoint, endPoint, capsuleRadius, capsuleDirection, capsuleDistance);

        foreach(RaycastHit hit2 in hits)
        {
            if(hit2.collider.tag == "Player")
            {
                float playerNoise_value = hit2.collider.GetComponent<playerMovement>().noiseValue;
                if(playerNoise_value == 0)
                {
                    Debug.Log("the monster doesn't hear you");
                    
                    audioPlayer.cuedSound = 0;
                    audioPlayer.playAudio_oneShot();
                    break;
                }
                else if (playerNoise_value == 1)
                {
                    Debug.Log("the monster can kinda hear you");
                    audioPlayer.cuedSound = 0;
                    audioPlayer.playAudio_oneShot();
                    //play audio for to let the player know the monster is close?
                    break;
                }
                else if (playerNoise_value == 2)
                {
                    Debug.Log("it heard you");
                    audioPlayer.cuedSound = 1;
                    audioPlayer.playAudio();
                    monster.switchState(monster.chase);
                    break;
                }
                else break;
            } 
        }
                //access the noise value from the playerMovement script
                //if noise is 0 do nothing/ return;
                //if noise is 1 play some audio to let the player know the monster is nearby
                //if noise is 2 or greater, enter the chase state

        //draw the capsule cast
        Debug.DrawRay(startPoint, capsuleDirection * capsuleDistance, Color.red);
        Debug.DrawRay(startPoint + capsuleAxis * capsuleRadius, capsuleDirection * capsuleDistance, Color.red);
        Debug.DrawRay(startPoint - capsuleAxis * capsuleRadius, capsuleDirection * capsuleDistance, Color.red);    
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
