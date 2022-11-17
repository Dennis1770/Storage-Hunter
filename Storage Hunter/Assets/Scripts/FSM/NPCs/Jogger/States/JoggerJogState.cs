using UnityEngine;
using UnityEngine.AI;

public class JoggerJogState : JoggerBaseState
{
    GameObject jogObject;

    //NavMeshAgent jogAgent;

    //GameObject[] waypoints;

    GameObject player;

    int interactRange = 4;

    //float minDistance = 1f;
    //public Transform currentWaypoint;
    //public int currentIndex;

    public override void EnterState(JoggerStateManager jogger)
    {
        //dialogue
        Debug.Log("Jogger is now in the jogging state");

        jogger.isJogging = true;

        jogObject = GameObject.FindGameObjectWithTag("Jogger");

        player = GameObject.FindGameObjectWithTag("Player");

        //navmesh
        //jogAgent = jogObject.GetComponent<NavMeshAgent>();

       // waypoints = GameObject.FindGameObjectsWithTag("Waypoint");

        //currentWaypoint = waypoints[0].transform;
    }

    public override void UpdateState(JoggerStateManager jogger)
    {
        /*
        Vector3 direction = currentWaypoint.transform.position;
        jogAgent.SetDestination(direction);

        for (int i=0; i < waypoints.Length; i++)
        {
            currentWaypoint = waypoints[i].transform;

            if (Vector3.Distance(currentWaypoint.transform.position, jogAgent.transform.position) < minDistance)
            {
                i++;

                if (i == waypoints.Length)
                {
                    i = 0;
                }
            }
        }
        */

        
        Vector3 distanceToPlayer = player.transform.position - jogObject.transform.position;
        if (distanceToPlayer.magnitude <= interactRange && !DialogueManager.GetInstance().dialogueIsPlaying && Input.GetKeyDown(KeyCode.E))
        {
            jogger.isJogging = false;
            jogger.switchState(jogger.talking);
        }
        
    }
}
