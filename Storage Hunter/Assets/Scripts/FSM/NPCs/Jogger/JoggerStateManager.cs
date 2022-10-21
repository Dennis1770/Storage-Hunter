using UnityEngine;

public class JoggerStateManager : MonoBehaviour
{
    JoggerBaseState currentState;

    public JoggerJogState jogging = new JoggerJogState();
    public JoggerTalkState talking = new JoggerTalkState();

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
