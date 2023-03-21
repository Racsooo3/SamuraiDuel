using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlaceCardTwoState : GameBaseState
{
    float localTimer;
    Timer timerText;

    public override void EnterState(GameStateManager game)
    {
        Debug.Log("PlaceCardTwoState");
        //Change displayname on the UI
        GameObject.Find("NameTag").GetComponent<NameTag>().ChangeText("P2", Color.blue);

        //Change cursor color
        GameObject.Find("GameManager").GetComponent<CursorTexture>().ChangeCursorColor("blue");

        //Remove cards on desk
        CardManager cardManager = GameObject.FindObjectOfType<CardManager>();
        cardManager.DeleteAllCard();
        //spawn cards
        cardManager.SpawnDeck(2);

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
            game.SwitchState(game.CalDamageState);
        }
    }

    public void EndTimer()
    {
        if (!DetermineIfMoreThan2CardLeftForPlayer2())
        {
            localTimer = 0;
        }
    }
    private bool DetermineIfMoreThan2CardLeftForPlayer2()
    {
        int[] count = new int[] { 0, 0, 0 };
        foreach (AttackType At in GameData.player2CardList)
        {
            count[(int)At]++;
        }
        foreach (AttackType At in GameData.player2CardOrder)
        {
            if (At != AttackType.Empty)
            {
                count[(int)At]--;
            }
        }
        for (int x = 3; x < 3; x++)
        {
            count[x] -= GameData.player2CardFold[x];
        }
        if (count[0] + count[1] + count[2] > 2)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
