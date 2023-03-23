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
            if (DetermineIfMoreThan2CardLeftForPlayer1())
            {
                RandomFoldCardUntilLeft2ForPlayer1();
            }
            game.SwitchState(game.PlaceCardTwoState);
        }
    }

    public void EndTimer()
    {
        if (!DetermineIfMoreThan2CardLeftForPlayer1())
        {
            localTimer = 0;
        }
    }

    private bool DetermineIfMoreThan2CardLeftForPlayer1()
    {
        int[] count= new int[] { 0, 0, 0 };
        foreach(AttackType At in GameData.player1CardList)
        {
            count[(int)At]++;
        }
        foreach (AttackType At in GameData.player1CardOrder)
        {
            if (At!= AttackType.Empty)
            {
                count[(int)At]--;
            }
        }
        for (int x =0; x < 3; x++)
        {
            count[x] -= GameData.player1CardFold[x];
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
    public void RandomFoldCardUntilLeft2ForPlayer1()
    {
        GameData.player1CardFold = new int[3] { 0, 0, 0 };
        int[] count = new int[] { 0, 0, 0 };
        foreach (AttackType At in GameData.player1CardList)
        {
            count[(int)At]++;
        }
        foreach (AttackType At in GameData.player1CardOrder)
        {
            if (At != AttackType.Empty)
            {
                count[(int)At]--;
            }
        }
        int leftCard = count[0] + count[1] + count[2];
        int[] fold = new int[3] { 0, 0, 0 };
        while (count[0] + count[1] + count[2] > 2)
        {
            if (count[2] > 0)
            {
                fold[2]++;
                count[2]--;
                continue;
            }
            if (count[1] > 0)
            {
                fold[1]++;
                count[1]--;
                continue;
            }
            if (count[0] > 0)
            {
                fold[0]++;
                count[0]--;
                continue;
            }
        }
        GameData.player1CardFold = fold;
    }
}
