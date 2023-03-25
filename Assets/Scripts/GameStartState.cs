using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartState : GameBaseState
{
    public override void EnterState(GameStateManager game)
    {
        Debug.Log("StartState");

        // Check wheather game is end
        if (GameData.currentRound >= GameData.totalNumberOfRound)
        {
            game.SwitchState(game.EndState);
        } else
        {
            // New Round has started // First round is = 1, second round = 2 ...
            GameData.currentRound++;
            GameObject.Find("Animation Panel").GetComponent<RoundAnimation>().DisplayRoundAnimation();

            // Update the round display
            RoundDisplay RD = GameObject.Find("Round Display").GetComponent<RoundDisplay>();
            RD.RoundTextDisplay(GameData.currentRound);

            game.SwitchState(game.CardDistributeState);
        }
    }

    public override void UpdateState(GameStateManager game)
    {
        
    }
}
