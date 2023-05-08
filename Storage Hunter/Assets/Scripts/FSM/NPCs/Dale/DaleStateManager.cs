using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaleStateManager : MonoBehaviour
{
    public DaleBaseState currentState;

    public DaleFollowState following = new DaleFollowState();
    public DaleTalkState talking = new DaleTalkState();
    public bool isFollowing = false;
    public bool isTalking = false;

    private void Start()
    {
        currentState = following;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void switchState(DaleBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
