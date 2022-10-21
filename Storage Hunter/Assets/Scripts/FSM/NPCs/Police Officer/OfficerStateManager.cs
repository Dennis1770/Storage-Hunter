using UnityEngine;

public class OfficerStateManager : MonoBehaviour
{
    OfficerBaseState currentState;

    public OfficerInvestigateState investigating = new OfficerInvestigateState();
    public OfficerTalkState talking = new OfficerTalkState();

    private void Start()
    {

    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void switchState(JoggerBaseState state)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
