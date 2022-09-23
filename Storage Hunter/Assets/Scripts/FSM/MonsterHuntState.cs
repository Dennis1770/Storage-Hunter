using UnityEngine;

public class MonsterHuntState : MonsterBaseState
{
    GameObject monster;

    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("Monster is now in the hunt state");
    }

    public override void UpdateState(MonsterStateManager monster)
    {

    }

    public override void OnCollisionEnter(MonsterStateManager monster)
    {

    }
}
