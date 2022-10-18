using UnityEngine;
using UnityEngine.AI;

/*This is one of the concrete states
 * it is self-contained
 * can have its own unique properties and methods
*/
public class MonsterChaseState : MonsterBaseState
{
    GameObject monster;

    GameObject player;

    NavMeshAgent agent;

    float escapeDistance = 15f;

    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("Monster is now in the chase state");

        agent = GameObject.FindObjectOfType<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        Vector3 direction = player.transform.position;
        agent.SetDestination(direction);

        if (Vector3.Distance(player.transform.position, agent.transform.position) >= escapeDistance)
        {
            monster.switchState(monster.idle);
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
