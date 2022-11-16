using UnityEngine;

public class OfficerInvestigateState : OfficerBaseState
{
    //GameObject officer;

    GameObject officerObject;

    GameObject player;

    int interactRange = 4; //how close you must be to talk to the npc

    public override void EnterState(OfficerStateManager officer)
    {
        Debug.Log("The Police Officer is now in the investigation state");

        officer.isInvestigating = true;

        officerObject = GameObject.FindGameObjectWithTag("Officer");

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void UpdateState(OfficerStateManager officer)
    {
        Vector3 distanceToPlayer = player.transform.position - officerObject.transform.position;
        //Debug.Log(distanceToPlayer.magnitude);
        if (distanceToPlayer.magnitude <= interactRange && !DialogueManager.GetInstance().dialogueIsPlaying && Input.GetKeyDown(KeyCode.E))
        {
            officer.isInvestigating = false;
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
