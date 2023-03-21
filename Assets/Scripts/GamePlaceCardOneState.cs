using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class GamePlaceCardOneState : GameBaseState
{
    float localTimer;
    Timer timerText;

    public override void EnterState(GameStateManager game)
    {
        Debug.Log("PlaceCardOneState");
        //Change displayname on the UI
        GameObject.Find("NameTag").GetComponent<NameTag>().ChangeText("P1", Color.red);

        //Change cursor color
        GameObject.Find("GameManager").GetComponent<CursorTexture>().ChangeCursorColor("red");

        //Remove cards on desk
        CardManager cardManager = GameObject.FindObjectOfType<CardManager>();
        cardManager.DeleteAllCard();
        //spawn cards
        cardManager.SpawnDeck(1);

        //timer ref
        localTimer = GameObject.FindObjectOfType<Settings>().GetEachRoundTimer();
        timerText = GameObject.FindObjectOfType<Timer>();

    }

    public override void UpdateState(GameStateManager game)
    {
        // Two ways to end this state :
        // 1.) Player pressed the "Next" button.
        // 2.) The timer is up


        if (localTimer > 0)
        {
            localTimer -= Time.deltaTime;
            timerText.SetTimeText(localTimer);
        }
        else
        {
            game.SwitchState(game.PlaceCardTwoState);
        }
    }

    public void EndTimer()
    {
        localTimer = 0;
    }
}
