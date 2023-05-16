using UnityEngine;
//Michael

//I should have made a generic state manager for the npcs a long time ago lol
public class GenericIdleState : GenericBaseState
{
    GameObject player;

    int interactRange = 4;
    public override void EnterState(GenericStateManager generic)
    {
        generic.isIdle = true;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void UpdateState(GenericStateManager generic, GameObject holdingObject)
    {
        Vector3 distanceToPlayer = player.transform.position - holdingObject.transform.position;
        if (distanceToPlayer.magnitude <= interactRange && !DialogueManager.GetInstance().dialogueIsPlaying && Input.GetKeyDown(KeyCode.E))
        {
            generic.isIdle = false;
            generic.switchState(generic.talking);
        }

    }
}
