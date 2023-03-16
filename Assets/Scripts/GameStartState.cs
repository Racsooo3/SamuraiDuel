using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartState : GameBaseState
{
    public override void EnterState(GameStateManager game)
    {
        GameData.Initialize();
        game.SwitchState(game.PlaceCardState);
    }

    public override void UpdateState(GameStateManager game)
    {
        
    }
}
