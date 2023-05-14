using UnityEngine;

public class KidStateManager : MonoBehaviour
{
    KidBaseState currentState;

    public KidIdleState playing = new KidIdleState();
    public KidTalkState talking = new KidTalkState();

    public bool isPlaying;
    public bool isTalking;

    private void Start()
    {
        currentState = playing;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void switchState(KidBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
