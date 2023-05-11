using UnityEngine;
using UnityEngine.AI;
//Michael
public class JoggerJogState : JoggerBaseState
{
    GameObject jogObject;

    NavMeshAgent jogAgent;

    GameObject[] waypoints;

    GameObject player;

    int interactRange = 4;

    float minDistance = 1f;
    public Transform currentWaypoint;
    public int currentIndex;
    private Animator animator;

    public override void EnterState(JoggerStateManager jogger)
    {
        //dialogue
        Debug.Log("Jogger is now in the jogging state");

        jogger.isJogging = true;

        jogObject = GameObject.FindGameObjectWithTag("Jogger");

        player = GameObject.FindGameObjectWithTag("Player");

        //navmesh
        jogAgent = jogObject.GetComponent<NavMeshAgent>();

        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");

        currentWaypoint = waypoints[currentIndex].transform;

        animator = jogObject.GetComponent<Animator>();
        animator.SetBool("isRunning", true);
    }

    public override void UpdateState(JoggerStateManager jogger)
    {
        Jog();

        Vector3 distanceToPlayer = player.transform.position - jogObject.transform.position;
        if (distanceToPlayer.magnitude <= interactRange && !DialogueManager.GetInstance().dialogueIsPlaying && Input.GetKeyDown(KeyCode.E))
        {
            jogAgent.SetDestination(player.transform.position - 3 * (distanceToPlayer.normalized)); //stop running when talking to the player
            jogger.isJogging = false;
            animator.SetBool("isRunning", false);
            jogger.switchState(jogger.talking);
        }
    }

    private void Jog()
    {

        Vector3 direction = currentWaypoint.transform.position;
        jogAgent.SetDestination(direction);

        if (Vector3.Distance(currentWaypoint.transform.position, jogObject.transform.position) < minDistance)
        {
            ++currentIndex;
            if (currentIndex > waypoints.Length - 1)
            {
                currentIndex = 0;
            }
            currentWaypoint = waypoints[currentIndex].transform;
        }
    }
}
