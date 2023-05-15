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
    float minDistance = 1f;
    public Transform currentWaypoint;
    public int currentIndex;

    /* this is too expensive on the cpu
        //capsulecast
        private float capsuleRadius = 3f;
        private float capsuleDistance = 40f;
        private float capsuleAngle = 30f; //30 degrees
        private float player_noiseValue;
    */

    //hearing
    private float hearingDistance = 100f;

    //raycast
    private float sightDistance = 60f;

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

        /*
                //Monster Hearing

                //calculate capsule raycast's start and end points
                Vector3 capsuleDirection = playerDirection;
                Vector3 startPoint = monsterAgent.transform.position;
                Vector3 endPoint = monsterAgent.transform.position + player.transform.position * capsuleDistance;


                        //calculate the axis of the capsule cast
                        Vector3 capsuleAxis = Vector3.Cross(capsuleDirection, Vector3.up).normalized;

                        //calculate the height and radius of the capsule
                        float capsuleHeight = Mathf.Sin(capsuleAngle * Mathf.Deg2Rad) * capsuleDistance;
                        Vector3 capsuleSize = new Vector3(capsuleRadius * 2f, capsuleHeight, capsuleRadius * 2f);

                        //perform the capsule cast
                        RaycastHit[] hits = Physics.CapsuleCastAll(startPoint, endPoint, capsuleRadius, capsuleDirection, capsuleDistance);

                        foreach (RaycastHit hit2 in hits)
                        {
                            if (hit2.collider.tag == "Player")
                            {

                                player_noiseValue = GameObject.FindObjectOfType<playerMovement>().noiseValue;
                                if (player_noiseValue == 0)
                                {
                                    Debug.Log("the monster doesn't hear you");

                                    audioPlayer.cuedSound = 0;
                                    audioPlayer.playAudio_oneShot();
                                    break;
                                }
                                else if (player_noiseValue == 1)
                                {
                                    Debug.Log("the monster can kinda hear you");
                                    audioPlayer.cuedSound = 0;
                                    audioPlayer.playAudio_oneShot();
                                    //play audio for to let the player know the monster is close?
                                    break;
                                }
                                else if (player_noiseValue == 2)
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
                */
    }
    /*
        void OnDrawGizmos() 
        {
            Vector3 capsuleDirection = monsterAgent.transform.forward;
            Vector3 startPoint = monsterAgent.transform.position;
            Vector3 endPoint = monsterAgent.transform.position + capsuleDirection * capsuleDistance;
            Gizmos.DrawWireSphere(startPoint, capsuleRadius);
            Gizmos.DrawWireSphere(endPoint, capsuleRadius);
        }
    */
    public override void OnCollisionEnter(MonsterStateManager monster, Collision collision)
    {
        //We are currently using the player to check for this collision

        /*
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            Debug.Log("game over"); //the player has been caught
        }
        */
    }

}
