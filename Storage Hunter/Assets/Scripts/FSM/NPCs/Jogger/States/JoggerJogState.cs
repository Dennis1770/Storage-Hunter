using UnityEngine;
using UnityEngine.AI;

public class JoggerJogState : JoggerBaseState
{
    GameObject jogger;

    Object[] agents;

    NavMeshAgent jogAgent;

    GameObject[] waypoints;

    float minDistance = 1f;
    public Transform currentWaypoint;
    public int currentIndex;

    public override void EnterState(JoggerStateManager jogger)
    {
        Debug.Log("Jogger is now in the jogging state");

        //jogAgent = GameObject.FindGameObjectWithTag("Jogger");

        agents = Object.FindObjectsOfType<NavMeshAgent>();

        foreach(object NavMeshAgent in agents)
        {
            Debug.Log(NavMeshAgent);
           
        }

        for(int i = 0; i < agents.Length; i++)
        {
            //GameObject.FindGameObjectsWithTag("Jogger");


        }
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
