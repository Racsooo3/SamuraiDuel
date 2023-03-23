using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class SinglePlayerAI 
{
    //enemy is player 2 
    public void AIRun()
    {
        bool isLastRound = GameData.currentRound >= GameData.totalNumberOfRound;
        // cal how many card dose enemy have in hand
        int enemyCardInHand = 0;
        foreach (AttackType tempcard in GameData.player1CardList)
        {
            if (tempcard != AttackType.Empty)
            {
                enemyCardInHand++;
            }
        }
        int myCardInHand = 0;
        foreach (AttackType tempcard in GameData.player2CardList)
        {
            if (tempcard != AttackType.Empty)
            {
                myCardInHand++;
            }
        }
        // if this is the last round card left is not consider
        // a card's usefulness is cal card win ++ card lose --
        if (isLastRound)
        {
            float[] usefullness = new float[myCardInHand];
            for(int x=0; x< myCardInHand; x++)
            {
                usefullness[x] = DetermineUsefullness(GameData.player1CardList[x]);
            }
            AttackType[] tempAT = new AttackType[] {AttackType.Empty, AttackType.Empty, AttackType.Empty};
            int count = 0;
            for(int x =5; x>-5 && count<4; x--)
            {
                for(int y=0;y<usefullness.Length && count<4; y++)
                {
                    if (usefullness[y]== x)
                    {
                        tempAT[count] = GameData.player2CardList[y];
                        usefullness[y] = -10;
                        count++;
                    }
                }
            }
            RandomToOrder(tempAT);
        }
        else
        {
            // random num that get form random of GameData.player2CardList
            int[] num = new int[3] { -1,-1,-1};
            num[0] = (int)Mathf.Floor(Random.Range(0f, (float)myCardInHand-0.01f));
            num[1] = num[0];
            while (num[0] == num[1])
            {
                num[1] = (int)Mathf.Floor(Random.Range(0f, (float)myCardInHand - 0.01f));
            }
            num[2] = num[0];
            while (num[2] == num[0] || num[2] == num[1])
            {
                num[2] = (int)Mathf.Floor(Random.Range(0f, (float)myCardInHand - 0.01f));
            }
            //random empty and card
            AttackType[] tempAt = new AttackType[3];
            for(int x =0; x < 3; x++)
            {
                if (Random.value < 0.9)
                {
                    tempAt[x] = GameData.player2CardList[num[x]];
                }
                else
                {
                    tempAt[x] = AttackType.Empty;
                }
            }
            RandomToOrder(tempAt);
             // more card to fold
            int[] count = new int[] { 0, 0, 0 };
            foreach(AttackType at in GameData.player2CardList)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (at == (AttackType)x)
                    {
                        count[x]++;
                    }
                }
            }
            foreach(AttackType at in tempAt)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (at == (AttackType)x)
                    {
                        count[x]--;
                    }
                }
            }
            while (count[0] + count[1] + count[2] > 2)
            {
                if (count[2] > 0)
                {
                    count[2]--;
                    continue;
                }
                if (count[1] > 0)
                {
                    count[2]--;
                    continue;
                }
                if (count[0] > 0)
                {
                    count[0]--;
                    continue;
                }
            }
            GameData.player2CardFold = count;
        }
        return;
    }
    private int DetermineUsefullness(AttackType At)
    {
        int usefullness = 0;
        if (At == AttackType.Slash)
        {
            foreach (AttackType at in GameData.player1CardList)
            {
                if (at == AttackType.Sneak)
                {
                    usefullness++;
                }
                if (at== AttackType.Counter)
                {
                    usefullness--;
                }
            }
            return usefullness;
        }
        if (At == AttackType.Counter)
        {
            foreach (AttackType at in GameData.player1CardList)
            {
                if (at == AttackType.Sneak)
                {
                    usefullness--;
                }
                if (at == AttackType.Slash)
                {
                    usefullness++;
                }
            }
            return usefullness;
        }
        if (At == AttackType.Sneak)
        {
            foreach (AttackType at in GameData.player1CardList)
            {
                if (at == AttackType.Counter)
                {
                    usefullness++;
                }
                if (at == AttackType.Slash)
                {
                    usefullness--;
                }
            }
            return usefullness;
        }
        return 0;
    }
    private void RandomToOrder(AttackType[] At)
    {
        GameData.player1CardOrder = new List<AttackType>{ AttackType.Empty, AttackType.Empty, AttackType.Empty };
        int first = (int)Mathf.Floor(Random.Range(0f, 2.99f));
        GameData.player2CardOrder[first] = At[0];
        int second = first;
        while (first == second)
        {
            second = (int)Mathf.Floor(Random.Range(0f, 2.99f));
        }
        GameData.player1CardOrder[second] = At[1];
        int third = 0;
        for(int x = 0; x < 3; x++)
        {
            if (x!=first && x != second)
            {
                third = x;
                break;
            }
        }
        GameData.player2CardOrder[third] = At[2];
    }
}
