using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
//Michael

/*This is one of the concrete states
 * it is self-contained
 * can have its own unique properties and methods
*/
public class MonsterChaseState : MonsterBaseState
{
    //GameObject monster;

    GameObject player;
    NavMeshAgent monsterAgent;

    private bool isSeen; //does the monster see the player?
    private Vector3 playerDirection; //the direction the player is in
    private Vector3 direction; //the player's position
    private float elapsedTime; //used to keep track of how long the monster has lost sight of the player for
    private float delay = 10; //the monster will wait this many seconds after loosing sight before changing from chase to patrol

    private Animator animator;

    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("Monster is now in the chase state");

        monsterAgent = GameObject.FindObjectOfType<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        direction = player.transform.position; //used for walking into the player
        playerDirection = (direction - monsterAgent.transform.position); //used for raycasting from the mosnter to the player

        if (isSeen == true)
        {
            monsterAgent.speed = 15;
            monsterAgent.stoppingDistance = 1;
            monsterAgent.SetDestination(direction); //when player is in sight, walk to them

            if (monsterAgent.pathStatus == NavMeshPathStatus.PathPartial) //player isn't reachable and is in sight
            {
                monsterAgent.SetDestination(monsterAgent.transform.position); //stand still
            }
        }
        else if (isSeen == false)
        {
            monsterAgent.speed = 12;
            monsterAgent.stoppingDistance = 6;
            elapsedTime += Time.deltaTime; //keep track of how long player is out of sight
            if (elapsedTime >= delay)
            {
                elapsedTime = 0f; //reset timer
                monster.switchState(monster.patrol); //patrol
            }

            if (monsterAgent.pathStatus == NavMeshPathStatus.PathPartial) //player isn't reachable and is out of sight
            {
                monster.switchState(monster.patrol); //patrol
            }
            else monsterAgent.SetDestination(direction);
        }

        //Monster Eyesight
        RaycastHit hit;
        Ray sightRay = new Ray(monsterAgent.transform.position, playerDirection);
        //Debug.DrawRay(monsterAgent.transform.position, playerDirection, Color.green);
        if (Physics.Raycast(sightRay, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                isSeen = true; //keep track of when the monster can see the player
            }
            else if (hit.collider.tag != "Player")
            {
                isSeen = false;
            }
        }
        else isSeen = false;
    }
}
