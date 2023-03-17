using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCalDamageState : GameBaseState
{
    List<AttackType> player1CardOrder = GameData.player1CardOrder;
    List<AttackType> player2CardOrder = GameData.player2CardOrder;

    public override void EnterState(GameStateManager game)
    {
        Debug.Log("CalDamageState");
        player1CardOrder = GameData.player1CardOrder;
        player2CardOrder = GameData.player2CardOrder;

        GameData.player1Health -= PlayerOneTotalDamage();
        GameData.player2Health -= PlayerTwoTotalDamage();
        Debug.Log("P1 HP: " + GameData.player1Health);
        Debug.Log("P2 HP: " + GameData.player2Health);

        // do all the card management
        CardManager cardManager = GameObject.FindObjectOfType<CardManager>();
        cardManager.DeleteUsedCardFromCardLeft();
        cardManager.AddCardToCardLastRount();

        game.SwitchState(game.AnimationState);
    }

    public override void UpdateState(GameStateManager game)
    {

    }

    private int PlayerOneTotalDamage()
    {
        //Compare cards in 3 slots
        int dmgReceivedInSlotOne = Function.CalDamage(player1CardOrder[0], player2CardOrder[0]);
        int dmgReceivedInSlotTwo = Function.CalDamage(player1CardOrder[1], player2CardOrder[1]);
        int dmgReceivedInSlotThree = Function.CalDamage(player1CardOrder[2], player2CardOrder[2]);
        return dmgReceivedInSlotOne + dmgReceivedInSlotTwo + dmgReceivedInSlotThree;
    }

    private int PlayerTwoTotalDamage()
    {
        //Compare cards in 3 slots
        int dmgReceivedInSlotOne = Function.CalDamage(player2CardOrder[0], player1CardOrder[0]);
        int dmgReceivedInSlotTwo = Function.CalDamage(player2CardOrder[1], player1CardOrder[1]);
        int dmgReceivedInSlotThree = Function.CalDamage(player2CardOrder[2], player1CardOrder[2]);
        return dmgReceivedInSlotOne + dmgReceivedInSlotTwo + dmgReceivedInSlotThree;
    }
}
