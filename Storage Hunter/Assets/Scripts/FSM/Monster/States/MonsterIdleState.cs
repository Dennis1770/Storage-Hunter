using UnityEngine;
using UnityEngine.AI;
//Michael

/*This is one of the concrete states
 * it is self-contained
 * can have its own unique properties and methods
*/
public class MonsterIdleState : MonsterBaseState
{
    GameObject monsterObject;
    private float elapsedTime;
    private float delay = 5; //the monster will wait this many seconds before changing from idle to patrol
    private Animator animator;

    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("Monster is now in the idle state");
        monsterObject = GameObject.FindGameObjectWithTag("Monster");

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
}
