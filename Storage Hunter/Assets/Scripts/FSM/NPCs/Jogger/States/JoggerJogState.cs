using UnityEngine;
using UnityEngine.AI;
//Michael
public class JoggerJogState : JoggerBaseState
{
    GameObject jogObject;

    NavMeshAgent jogAgent;

    GameObject[] waypoints;

    GameObject player;

    int interactRange = 10;

    float minDistance = 1f;
    public GameObject currentWaypoint;
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

        /*
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        currentWaypoint = waypoints[currentIndex].transform;
        */
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint"); //compile an array of waypoint
        currentWaypoint = GameObject.Find($"Waypoint{currentIndex}");

        animator = jogObject.GetComponent<Animator>();
        animator.SetBool("isRunning", true);
    }

    public override void UpdateState(JoggerStateManager jogger)
    {
        Jog();

        Vector3 distanceToPlayer = player.transform.position - jogObject.transform.position;
        if (distanceToPlayer.magnitude <= interactRange && !DialogueManager.GetInstance().dialogueIsPlaying && Input.GetKeyDown(KeyCode.E))
        {
            jogAgent.SetDestination(jogAgent.transform.position); //stop running
            jogObject.transform.LookAt(player.transform);
            jogger.isJogging = false;
            animator.SetBool("isRunning", false);
            jogger.switchState(jogger.talking);
        }
    }

    private void Jog()
    {
        if (Vector3.Distance(currentWaypoint.transform.position, jogObject.transform.position) < minDistance)
        {
            ++currentIndex;
            if (currentIndex > waypoints.Length - 1)
            {
                currentIndex = 0;
            }
            currentWaypoint = GameObject.Find($"Waypoint{currentIndex}"); //The waypoints must be named Waypoint0, Waypoint1, Waypoint2, etc. for this to work
        }

        Vector3 direction = currentWaypoint.transform.position;
        jogAgent.SetDestination(direction);
    }
}
