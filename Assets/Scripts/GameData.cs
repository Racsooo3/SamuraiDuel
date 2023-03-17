using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    private static int maxHealth = 100;
    private static int totalNumberOfRound = 3;

    public static int player1Health = 100;
    public static int player2Health = 100;

    public static int player1SlashLeft;
    public static int player1SneakLeft;
    public static int player1CounterLeft;

    public static int player2SlashLeft;
    public static int player2SneakLeft;
    public static int player2CounterLeft;

    //********************************************************************************************************************
    //********************************************************************************************************************
    // After the player uses every card, make sure renew what card is left, and remove the card from the list below
    //********************************************************************************************************************
    //********************************************************************************************************************

    public static List<AttackType> player1CardList = new List<AttackType>();
    public static List<AttackType> player2CardList = new List<AttackType>();

    public static List<AttackType> player1CardOrder = new List<AttackType> {AttackType.Empty, AttackType.Empty, AttackType.Empty };
    public static List<AttackType> player2CardOrder = new List<AttackType> {AttackType.Empty, AttackType.Empty, AttackType.Empty };

    public static List<AttackType> player1CardLastRound = new List<AttackType>() ;
    public static List<AttackType> player2CardLastRound = new List<AttackType>() ;

    public static void ResetCardOrder(int playerNum)
    {
        if (playerNum == 1)
        {
            player1CardOrder = new List<AttackType> { AttackType.Empty, AttackType.Empty, AttackType.Empty };
        }
        else
        {
            player2CardOrder = new List<AttackType> { AttackType.Empty, AttackType.Empty, AttackType.Empty };
        }
    }
    public static List<AttackType> GetPlayerCardList(int playerNum)
    {
        if (playerNum == 1)
        {
            return player1CardList;
        }
        else if (playerNum == 2)
        {
            return player2CardList;
        }
        else return null;
    }

    public static int[] GetPlayerCardLeft(int playerNum)
    {
        if (playerNum == 1)
        {
            return new int[]  { player1SlashLeft , player1SneakLeft , player1CounterLeft };
        }
        if (playerNum == 2)
        {
            return new int[] { player2SlashLeft, player2SneakLeft, player2CounterLeft };
        }
        return null;
    }

    public static void Initialize()
    {
        player1Health = maxHealth;
        player2Health = maxHealth;

        player1SlashLeft = totalNumberOfRound;
        player1SneakLeft = totalNumberOfRound;
        player1CounterLeft = totalNumberOfRound;

        player2SlashLeft = totalNumberOfRound;
        player2SneakLeft = totalNumberOfRound;
        player2CounterLeft = totalNumberOfRound;

    }
}
