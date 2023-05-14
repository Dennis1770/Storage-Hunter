using UnityEngine;
using UnityEngine.AI;
//Michael
public class DaleFollowState : DaleBaseState
{
    GameObject daleObject;
    GameObject player;
    private NavMeshAgent daleAgent;
    private int interactRange = 6;
    float followDistance = 10;
    public Transform currentWaypoint_Dale;
    private Animator animator;


    public override void EnterState(DaleStateManager dale)
    {
        //Debug.Log($"Dale is now in the follow state");
        dale.isFollowing = true;
        daleObject = GameObject.FindGameObjectWithTag("Dale");
        player = GameObject.FindGameObjectWithTag("Player");

        daleAgent = daleObject.GetComponent<NavMeshAgent>();
        currentWaypoint_Dale = player.transform;

        animator = daleObject.GetComponent<Animator>();
    }

    public override void UpdateState(DaleStateManager dale)
    {
        Vector3 distanceToPlayer = player.transform.position - daleObject.transform.position;
        if (distanceToPlayer.magnitude <= interactRange && !DialogueManager.GetInstance().dialogueIsPlaying && Input.GetKeyDown(KeyCode.E))
        {
            dale.isFollowing = false;
            dale.switchState(dale.talking);
        }

        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (Vector3.Distance(currentWaypoint_Dale.transform.position, daleObject.transform.position) > followDistance)
        {
            //Debug.Log($"Dale is {Vector3.Distance(currentWaypoint_Dale.transform.position, daleObject.transform.position)} units away from the player");
            Vector3 direction = currentWaypoint_Dale.transform.position;
            daleAgent.SetDestination(direction);
            animator.SetBool("isWalking", true);
        }
        else
        {
            daleAgent.SetDestination(daleObject.transform.position);
            animator.SetBool("isWalking", false);
        }
    }
}
