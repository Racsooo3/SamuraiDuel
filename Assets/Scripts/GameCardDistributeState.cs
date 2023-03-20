using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCardDistributeState : GameBaseState
{
    public override void EnterState(GameStateManager game)
    {
        Debug.Log("CardDistributeState");

        // New Round has started
        GameData.currentRound++;

        if (GameData.currentRound >= GameData.totalNumberOfRound)
        {
            game.SwitchState(game.EndState);
        }

        // Displays //
        // Update Card Left Display (Left and Right side)
        GameObject.FindObjectOfType<CardLeftDisplay>().UpdateCardLeftDisplay();

        GameData.player1CardList = new List<AttackType>();
        GameData.player2CardList = new List<AttackType>();

        // Add card from LAST round
        foreach (AttackType cards in GameData.player1CardLastRound)
        {
            GameData.player1CardList.Add(cards);
        }
        foreach (AttackType cards in GameData.player2CardLastRound)
        {
            GameData.player2CardList.Add(cards);
        }
        GameData.player1CardLastRound = new List<AttackType>();
        GameData.player2CardLastRound = new List<AttackType>();

        //Distribute Cards
        AttackType[] player1CardsGetInThisRound = Function.CardDistribute(1);
        AttackType[] player2CardsGetInThisRound = Function.CardDistribute(2);

        // Add card from THIS round
        foreach (AttackType cards in player1CardsGetInThisRound)
        {
            GameData.player1CardList.Add(cards);
        }
        foreach (AttackType cards in player2CardsGetInThisRound)
        {
            GameData.player2CardList.Add(cards);
        }

        //Removed card left in this round
        Function.DeleteFromCardLeft(1, player1CardsGetInThisRound);
        Function.DeleteFromCardLeft(2, player2CardsGetInThisRound);

        GameData.ResetCardOrder(1);
        GameData.ResetCardOrder(2);
        /*GameData.player1CardOrder = new List<AttackType> { AttackType.Empty, AttackType.Empty, AttackType.Empty };
        GameData.player2CardOrder = new List<AttackType> { AttackType.Empty, AttackType.Empty, AttackType.Empty };*/

        // Displays //
        GameObject.FindObjectOfType<CardLeftDisplay>().UpdateCardColorDisplay();

        game.SwitchState(game.PlaceCardOneState);
    }

    public override void UpdateState(GameStateManager game)
    {

    }
}
