using UnityEngine;

public class OfficerTalkState : OfficerBaseState
{
    //GameObject officer;

    GameObject officerObject;

    GameObject player;

    //GameObject officerCanvas;

    public override void EnterState(OfficerStateManager officer)
    {
        Debug.Log("The Police Officer is now in the talk state");

        officer.isTalking = true;

        officerObject = GameObject.FindGameObjectWithTag("Officer");

        //officerObject.transform.LookAt(player.transform); //npc should turn to face the player

        player = GameObject.FindGameObjectWithTag("Player");

        
    }

    public override void UpdateState(OfficerStateManager officer)
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            officer.isTalking = false;
            officer.switchState(officer.investigating);
        }
    }

    /*
    public override void OnCollisionEnter(OfficerStateManager officer, Collision collision)
    {
        throw new System.NotImplementedException();
    }
    */

}


