using UnityEngine;

public class OfficerStateManager : MonoBehaviour
{
    public OfficerBaseState currentState;

    public OfficerInvestigateState investigating = new OfficerInvestigateState();
    public OfficerTalkState talking = new OfficerTalkState();
    public bool isInvestigating = false;
    public bool isTalking = false;

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