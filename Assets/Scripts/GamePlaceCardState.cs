using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlaceCardState : GameBaseState
{
    public override void EnterState(GameStateManager game)
    {
        Debug.Log("PlaceCardState");
        ShowCardOfPlayer(1);
    }

    public override void UpdateState(GameStateManager game)
    {

    }

    private void ShowCardOfPlayer(int playerNum)
    {
        CardManager cardManager = GameObject.FindObjectOfType<CardManager>();
        cardManager.SpawnDeck(playerNum);
    }

}
