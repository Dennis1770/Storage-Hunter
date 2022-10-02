using UnityEngine;

/*This is one of the concrete states
 * it is self-contained
 * can have its own unique properties and methods
*/
public class MonsterChaseState : MonsterBaseState
{
    GameObject monster;

    //MonsterStateManager stateManager;

    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("Monster is now in the chase state");
    }

    public override void UpdateState(MonsterStateManager monster)
    {

    }

    public override void OnCollisionEnter(MonsterStateManager monster, Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            Debug.Log("game over");
            //the player has been caught
        }
    }
}
