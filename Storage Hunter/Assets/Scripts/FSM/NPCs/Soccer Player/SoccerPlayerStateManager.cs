using UnityEngine;

public class SoccerPlayerStateManager : MonoBehaviour
{
    SoccerPlayerBaseState currentState;

    public SoccerPlayerSoccerState playing = new SoccerPlayerSoccerState();
    public SoccerPlayerTalkState talking = new SoccerPlayerTalkState();

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
