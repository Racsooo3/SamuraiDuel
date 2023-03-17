using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlaceCardOneState : GameBaseState
{
    public override void EnterState(GameStateManager game)
    {
        Debug.Log("PlaceCardState");
        CardManager cardManager = GameObject.FindObjectOfType<CardManager>();
        cardManager.SpawnDeck(1);
    }

    public override void UpdateState(GameStateManager game)
    {

    }

}
