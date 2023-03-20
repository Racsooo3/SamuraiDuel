using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLeft
{
    public GameObject cardObject;
    public AttackType attackType;

    public CardLeft(GameObject cardObject, AttackType attackType)
    {
        this.cardObject = cardObject;
        this.attackType = attackType;
    }
}
