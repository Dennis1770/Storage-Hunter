using UnityEngine;

public class OfficerStateManager : MonoBehaviour
{
    OfficerBaseState currentState;

    public OfficerInvestigateState investigating = new OfficerInvestigateState();
    public OfficerTalkState talking = new OfficerTalkState();

    private void Start()
    {
        currentState = investigating;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void switchState(OfficerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }
    */
}
