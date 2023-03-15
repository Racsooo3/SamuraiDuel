using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Function
{
    // intput the two Type of the attack 
    //return the damage that I take
    // out -1 if error
    public static int CalDamage(AttackType myType , AttackType opponentType)
    {
        switch (myType)
        {
            case AttackType.Sneak:
                switch (opponentType)
                {
                    case AttackType.Sneak:
                        return 1;
                    case AttackType.Slash:
                        return 2;
                    case AttackType.Counter:
                        return 0;
                }
                break;
            case AttackType.Counter:
                switch (opponentType)
                {
                    case AttackType.Sneak:
                        return 1;
                    case AttackType.Slash:
                        return 0;
                    case AttackType.Counter:
                        return 0;
                }
                break;
            case AttackType.Slash:
                switch (opponentType)
                {
                    case AttackType.Sneak:
                        return 0;
                    case AttackType.Slash:
                        return 2;
                    case AttackType.Counter:
                        return 1;
                }
                break;
        }
        return -1;
    }

    // return a array that random distrubt card from the card left
    public static AttackType[] CardDistribute(int playerNum)
    {
        AttackType[] result = new AttackType[3];
        int[] deck = GameData.GetPlayerCardLeft(playerNum);
        for (int x =0; x < 3; x++)
        {
            int randomcard  = Random.Range(1, deck[0] + deck[1] + deck[2]);
            if(randomcard - deck[2] <= 0)
            {
                result[x] = AttackType.Counter;
            }
            else if (randomcard - deck[1] - deck[2] <= 0)
            {
                result[x] = AttackType.Sneak;
            }
            else
            {
                result[x] = AttackType.Slash;
            }
        }
        return result;
    }

}
