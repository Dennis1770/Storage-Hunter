using UnityEngine;
//Michael

/*This is one of the concrete states
 * it is self-contained
 * can have its own unique properties and methods
*/
public class MonsterIdleState : MonsterBaseState
{
    //GameObject monster;

    GameObject monsterObject;

    //MonsterStateManager stateManager;

    private float elapsedTime;
    private float delay; //the monster will wait this many seconds before changing from idle to patrol
    private Animator animator;

    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("Monster is now in the idle state");
        monsterObject = GameObject.FindGameObjectWithTag("Monster");

        delay = Random.Range(1, 4); //wait 1-3 seconds
        Debug.Log("The monster will wait " + delay + " seconds before patrolling");

        animator = monsterObject.GetComponent<Animator>();
        animator.SetBool("isWalking", false);
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= delay)
        {
            //reset the timer
            elapsedTime = 0.0f;
            //change state
            monster.switchState(monster.patrol);
            animator.SetBool("isWalking", true);
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
