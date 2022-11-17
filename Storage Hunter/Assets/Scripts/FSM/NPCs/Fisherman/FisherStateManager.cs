using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherStateManager : MonoBehaviour
{
    public FisherBaseState currentState;

    public FisherFishState fishing = new FisherFishState();
    public FisherTalkState talking = new FisherTalkState();
    public bool isFishing = false;
    public bool isTalking = false;

    private void Start()
    {
        currentState = fishing;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void switchState(FisherBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
