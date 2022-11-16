using UnityEngine;
using UnityEngine.AI;

public class OfficerInvestigateState : OfficerBaseState
{
    //GameObject officer;

    GameObject officerObject;

    NavMeshAgent officerAgent;

    GameObject Player;

    float interactRange; //how close you must be to talk to the npc

    public override void EnterState(OfficerStateManager officer)
    {
        Debug.Log("The Police Officer is now in the investigation state");

        officerObject = GameObject.FindGameObjectWithTag("Officer");

        officerAgent = officerObject.GetComponent<NavMeshAgent>();

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void UpdateState(OfficerStateManager officer)
    {
        Vector3 distanceToPlayer = Player.transform.position - officerObject.transform.position;
        if(distanceToPlayer.magnitude <= interactRange && Input.GetKeyDown(KeyCode.E))
        {
            officer.switchState(officer.talking);
        }
    }

    /*
    public override void OnCollisionEnter(OfficerStateManager officer, Collision collision)
    {
        throw new System.NotImplementedException();
    }
    */
}
