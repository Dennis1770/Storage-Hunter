using UnityEngine;

public class JoggerStateManager : MonoBehaviour
{
    JoggerBaseState currentState;

    public JoggerJogState jogging = new JoggerJogState();
    public JoggerTalkState talking = new JoggerTalkState();

    private void Start()
    {
        currentState = jogging;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void switchState(JoggerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }
}
