using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

/*This is one of the concrete states
 * it is self-contained
 * can have its own unique properties and methods
*/
public class MonsterChaseState : MonsterBaseState
{
    //GameObject monster;

    GameObject player;

    NavMeshAgent monsterAgent;

    float escapeDistance = 70f;
    private float elapsedTime;
    private float delay = 10; //the monster will wait this many seconds before changing from chase to idle

    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("Monster is now in the chase state");

        monsterAgent = GameObject.FindObjectOfType<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        Vector3 direction = player.transform.position;
        monsterAgent.SetDestination(direction);

        if (Vector3.Distance(player.transform.position, monsterAgent.transform.position) >= escapeDistance) //If the player runs far enough away from the monster, it will lose interest
        {
            elapsedTime += Time.deltaTime;
            //Debug.Log("distance: " + elapsedTime);
            if(elapsedTime >= delay)
            {
                elapsedTime = 0f;
                monster.switchState(monster.idle);
            }
        }

        //Monster Eyesight
        RaycastHit hit;
        Ray sightRay = new Ray(monsterAgent.transform.position, monsterAgent.transform.TransformDirection(Vector3.forward));
        Debug.DrawRay(monsterAgent.transform.position, monsterAgent.transform.TransformDirection(Vector3.forward) * 14f, Color.green);
        if (Physics.Raycast(sightRay, out hit))
        {
            if (hit.collider.tag != "Player") //When the player is in a storage locker, the monster will lose interest.
            {
                elapsedTime += Time.deltaTime;
                //Debug.Log("LOS: " + elapsedTime);
                if(elapsedTime >= delay)
                {
                    elapsedTime = 0f;
                    monster.switchState(monster.idle);
                }
            }
        }
    }

    public override void OnCollisionEnter(MonsterStateManager monster, Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
            Debug.Log("game over");
            //the player has been caught
        }
    }
}
