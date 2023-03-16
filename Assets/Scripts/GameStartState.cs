using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartState : GameBaseState
{
    public override void EnterState(GameStateManager game)
    {
        Debug.Log("StartState");

        GameData.Initialize();
        game.SwitchState(game.CardDistributeState);
    }

    public override void UpdateState(GameStateManager game)
    {
        
    }
}
