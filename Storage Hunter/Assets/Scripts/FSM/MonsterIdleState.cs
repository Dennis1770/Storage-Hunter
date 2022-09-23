using UnityEngine;

public class MonsterIdleState : MonsterBaseState
{
    GameObject monster;

    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("Monster is now in the idle state");
    }

    public override void UpdateState(MonsterStateManager monster)
    {

    }

    public override void OnCollisionEnter(MonsterStateManager monster)
    {
        //monster.switchState(monster.chase);
    }
}
