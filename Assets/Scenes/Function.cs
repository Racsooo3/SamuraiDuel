using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function
{
    // intput the two Type of the attack 
    //return the damage that I take
    // out -1 if error
    public int CalDamage(AttackType myType , AttackType opponentType)
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
}
