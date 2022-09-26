using UnityEngine;

/*This script is the abstract state
 * its methods are used in each concrete state which reference it
*/

public abstract class MonsterBaseState
{
    public abstract void EnterState(MonsterStateManager monster);

    public abstract void UpdateState(MonsterStateManager monster);

    public abstract void OnCollisionEnter(MonsterStateManager monster);
}
