using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCardDistributeState : GameBaseState
{
    public override void EnterState(GameStateManager game)
    {
        Debug.Log("CardDistributeState");

        //Distribute Cards
        AttackType[] player1CardsGetInThisRound = Function.CardDistribute(1);
        AttackType[] player2CardsGetInThisRound = Function.CardDistribute(2);

        foreach (AttackType cards in player1CardsGetInThisRound)
        {
            GameData.player1CardList.Add(cards);
        }
        foreach (AttackType cards in player2CardsGetInThisRound)
        {
            GameData.player2CardList.Add(cards);
        }

        game.SwitchState(game.PlaceCardOneState);
    }

    public override void UpdateState(GameStateManager game)
    {

    }
}
