using UnityEngine;
//Michael
public class KidIdleState : KidBaseState
{
    GameObject kidObject;
    GameObject player;
    int interactRange = 6;
    public override void EnterState(KidStateManager kid)
    {
        Debug.Log("Kid is now in the play state");

        kid.isPlaying = true;

        kidObject = GameObject.FindGameObjectWithTag("kid");

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void UpdateState(KidStateManager kid)
    {
        Vector3 distanceToPlayer = player.transform.position - kidObject.transform.position;
        if (distanceToPlayer.magnitude <= interactRange && !DialogueManager.GetInstance().dialogueIsPlaying && Input.GetKeyDown(KeyCode.E))
        {
            kid.isTalking = true;
            kid.switchState(kid.talking);
        }
    }
}
