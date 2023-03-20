using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitiateState : GameBaseState
{
    public override void EnterState(GameStateManager game)
    {
        Debug.Log("InitiateState");

        GameData.Initialize();
        game.SwitchState(game.StartState);
    }

    public override void UpdateState(GameStateManager game)
    {

    }
}
