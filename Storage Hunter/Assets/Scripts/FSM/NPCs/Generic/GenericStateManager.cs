using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Michael
public class GenericStateManager : MonoBehaviour
{
    public GenericBaseState currentState;

    public GenericIdleState idle = new GenericIdleState();
    public GenericTalkState talking = new GenericTalkState();
    public bool isIdle = false;
    public bool isTalking = false;

    private void Start()
    {
        currentState = idle;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this, gameObject);
    }

    public void switchState(GenericBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}