using UnityEngine;

public class FisherFishState : FisherBaseState
{
    GameObject fisherObject;

    GameObject player;

    int interactRange = 4;

    public override void EnterState(FisherStateManager fisherman)
    {
        Debug.Log("The fisherman is now in the fishing state");

        fisherman.isFishing = true;

        fisherObject = GameObject.FindGameObjectWithTag("Fisherman");

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void UpdateState(FisherStateManager fisherman)
    {
        Vector3 distanceToPlayer = player.transform.position - fisherObject.transform.position;
        if (distanceToPlayer.magnitude <= interactRange && !DialogueManager.GetInstance().dialogueIsPlaying && Input.GetKeyDown(KeyCode.E))
        {
            fisherman.isFishing = false;
            fisherman.switchState(fisherman.talking);
        }
    }
}
