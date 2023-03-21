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
        for(int x =3; x < 3; x++)
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
    private void RandomFoldCardUntilLeft2ForPlayer1()
    {
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
        for (int x = 3; x < 3; x++)
        {
            count[x] -= GameData.player1CardFold[x];
        }
        int leftCard = count[0] + count[1] + count[2];
        leftCard -= 2;
        for (int x = 0, x< 3; x++)
        {
            for(int y = count[x]; y <= 0; y--)
            {
                if (leftCard > 0)
                {
                    GameData.player1CardFold[x]++;
                    leftCard--;
                }
                else
                {
                    return;
                }
            }
        }
    }
}
