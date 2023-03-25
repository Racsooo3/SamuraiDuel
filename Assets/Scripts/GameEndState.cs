using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndState : GameBaseState
{
    public override void EnterState(GameStateManager game)
    {
        Debug.Log("EndState");
        int P1_final_score = GameData.player1Dominates;
        int P2_final_score = GameData.player2Dominates;

        if (P1_final_score > P2_final_score)
        {
            Debug.Log("P1 wins");
        } 
        else if (P2_final_score > P1_final_score)
        {
            Debug.Log("P2 wins");
        } else
        {
            Debug.Log("Draw");
        }
    }

    public override void UpdateState(GameStateManager game)
    {

    }
}
