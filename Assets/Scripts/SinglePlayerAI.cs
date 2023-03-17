using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerAI 
{
    //enemy is player 2 
    public AttackType[] Ai(bool isLastRound)
    {
        // cal how many card dose enemy have in hand
        int enemyCardInHand = 0;
        foreach (AttackType tempcard in GameData.player1CardList)
        {
            if (tempcard != AttackType.Empty)
            {
                enemyCardInHand++;
            }
        }

        // if this is the last round card left is not consider
        // a card's usefulness is cal by (enemy cards that it win against)/ (total enemy card)
        if (isLastRound)
        {
            float[] usefullness = new float[3];
        }
        return null;
    }
}
