using UnityEngine;
using UnityEngine.AI;

public class JoggerJogState : JoggerBaseState
{
    GameObject jogger;

    GameObject jogObject;

    NavMeshAgent jogAgent;

    GameObject[] waypoints;

    float minDistance = 1f;
    public Transform currentWaypoint;
    public int currentIndex;

    public override void EnterState(JoggerStateManager jogger)
    {
        Debug.Log("Jogger is now in the jogging state");

        jogObject = GameObject.FindGameObjectWithTag("Jogger");

        jogAgent = jogObject.GetComponent<NavMeshAgent>();

    }

    public override void UpdateState(JoggerStateManager jogger)
    {
        //throw new System.NotImplementedException();
    }

    public override void OnCollisionEnter(JoggerStateManager jogger, Collision collision)
    {
        //throw new System.NotImplementedException();
    }
}
