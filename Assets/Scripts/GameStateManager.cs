using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private bool SinglePlayer;
    public GameBaseState currentState;
    public GameInitiateState InitiateState = new GameInitiateState();
    public GameStartState StartState = new GameStartState();
    public GameAnimationState AnimationState = new GameAnimationState();
    public GameCardDistributeState CardDistributeState = new GameCardDistributeState();
    public GamePlaceCardOneState PlaceCardOneState = new GamePlaceCardOneState();
    public GamePlaceCardTwoState PlaceCardTwoState = new GamePlaceCardTwoState();
    public GameCalDamageState CalDamageState = new GameCalDamageState();
    public GameEndState EndState = new GameEndState();

    private void Start()
    {
        currentState = InitiateState;

        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(GameBaseState state)
    {
        if(state== PlaceCardTwoState && SinglePlayer)
        {
            SinglePlayerState();
            state = CalDamageState;
        }
        currentState = state;
        state.EnterState(this);
    }
    // skip player2 state and run the AI
    private void SinglePlayerState()
    {
        SinglePlayerAI singlePlayerAI = new SinglePlayerAI();
        singlePlayerAI.AIRun();
    }
}
