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

        //Display helper if its turned on
        if (GameObject.Find("GameManager").GetComponent<Settings>().GetEyeHelper() == true)
        {
            GameObject.Find("EyeHelperAnimation").GetComponent<EyeHelper>().ShowHelpers(true);
            GameObject.Find("EyeHelperAnimation").GetComponent<EyeHelper>().PlayersTurn(2);
        } else
        {
            GameObject.Find("EyeHelperAnimation").GetComponent<EyeHelper>().ShowHelpers(false);
        }
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
            if (DetermineIfMoreThan2CardLeftForPlayer2())
            {
                RandomFoldCardUntilLeft2ForPlayer2();
            }
            game.SwitchState(game.CalDamageState);
        }
    }

    public bool EndTimer()
    {
        if (!DetermineIfMoreThan2CardLeftForPlayer2())
        {
            localTimer = 0;
            return true;// Time is reduced
        }
        return false; // Time reduction failed.
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
        for (int x = 0; x < 3; x++)
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
    public void RandomFoldCardUntilLeft2ForPlayer2()
    {
        GameData.player2CardFold = new int[3] { 0,0,0};
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
        int leftCard = count[0] + count[1] + count[2];
        int[] fold = new int[3] { 0, 0, 0 };
        while(count[0] + count[1] + count[2]>2)
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
        GameData.player2CardFold = fold;
    }
}
