using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCheckListInRound : MonoBehaviour
{
    public bool haveDistributedCard;
    public bool havePlayerOnePlaced;
    public bool havePlayerTwoPlaced;
    public bool haveAnimated;

    public void ResetActionCheckListInRound()
    {
        haveDistributedCard = false;
        havePlayerOnePlaced = false;
        havePlayerTwoPlaced = false;
        haveAnimated = false;
    }
}
