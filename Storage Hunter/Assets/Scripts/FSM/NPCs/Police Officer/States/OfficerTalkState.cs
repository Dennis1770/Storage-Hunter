using UnityEngine;
using UnityEngine.AI;

public class OfficerTalkState : OfficerBaseState
{
    //GameObject officer;

    GameObject officerObject;

    NavMeshAgent officerAgent;

    GameObject player;

    GameObject officerCanvas;

    public override void EnterState(OfficerStateManager officer)
    {
        Debug.Log("The Police Officer is now in the talk state");

        officerObject.transform.LookAt(player.transform); //npc will face the player

        officerCanvas = GameObject.FindGameObjectWithTag("OfficerCanvas");

        officerCanvas.SetActive(true); //start the inky dialogue
    }

    public override void UpdateState(OfficerStateManager officer)
    {
        return;
    }

    /*
    public override void OnCollisionEnter(OfficerStateManager officer, Collision collision)
    {
        throw new System.NotImplementedException();
    }
    */
}
