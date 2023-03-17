using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ActionCheckListInRound
{
    public static bool haveDistributedCard;
    public static bool havePlayerOnePlaced;
    public static bool havePlayerTwoPlaced;
    public static bool haveAnimated;

    public static void ResetActionCheckListInRound()
    {
        haveDistributedCard = false;
        havePlayerOnePlaced = false;
        havePlayerTwoPlaced = false;
        haveAnimated = false;
    }
}
