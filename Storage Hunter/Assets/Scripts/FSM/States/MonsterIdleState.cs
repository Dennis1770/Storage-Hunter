using UnityEngine;

/*This is one of the concrete states
 * it is self-contained
 * can have its own unique properties and methods
*/
public class MonsterIdleState : MonsterBaseState
{
    GameObject monster;

    private float elapsedTime;
    private float delay = 3.0f; //the monster will wait this many seconds before changing from idle to patrol


    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("Monster is now in the idle state");
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= delay)
        {
            //reset the timer
            elapsedTime = 0.0f;
            //change state
            monster.switchState(monster.patrol);
        }
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
