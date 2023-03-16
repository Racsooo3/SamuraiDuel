using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameBaseState currentState;
    public GameStartState StartState = new GameStartState();
    public GameAnimationState AnimationState = new GameAnimationState();
    public GameCardDistributeState CardDistributeState = new GameCardDistributeState();
    public GamePlaceCardState PlaceCardState = new GamePlaceCardState();
    public GameEndState EndState = new GameEndState();

    private void Start()
    {
        currentState = StartState;

        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(GameBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
