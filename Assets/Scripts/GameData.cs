using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    [SerializeField] private static int maxHealth;
    [SerializeField] private static int totalNumberOfRound;

    public static int player1Health;
    public static int player2Health;

    public static int player1SlashLeft;
    public static int player1SneakLeft;
    public static int player1CounterLeft;

    public static int player2SlashLeft;
    public static int player2SneakLeft;
    public static int player2CounterLeft;

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

    public static void initialize()
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
