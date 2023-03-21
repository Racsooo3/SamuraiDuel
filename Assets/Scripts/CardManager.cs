using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Slots;
    [SerializeField] private GameObject Deck;
    [SerializeField] private GameObject Fold;
    [SerializeField] private GameObject slashCard;
    [SerializeField] private GameObject sneakCard;
    [SerializeField] private GameObject counterCard;

    // one function for two player
    public void AddCardToCardLastRound()
    {
        int[] count = new int[] {0,0,0};
        foreach(AttackType tempCardInList in GameData.player1CardList)
        {
            for(int x = 0; x < 3; x++)
            {
                if (tempCardInList == (AttackType)x)
                {
                    count[x]++;
                }
            }
        }
        foreach (AttackType tempCardInOrder in GameData.player1CardOrder)
        {
            for (int x = 0; x < 3; x++)
            {
                if (tempCardInOrder == (AttackType)x)
                {
                    count[x]--;
                }
            }
        }
        for(int x=0; x < 3; x++)
        {
            for (int y=0; y< count[x]; y++)
            {
                GameData.player1CardLastRound.Add((AttackType)x);
            }
        }

        count = new int[] { 0, 0, 0 };
        foreach (AttackType tempCardInList in GameData.player2CardList)
        {
            for (int x = 0; x < 3; x++)
            {
                if (tempCardInList == (AttackType)x)
                {
                    count[x]++;
                }
            }
        }
        foreach (AttackType tempCardInOrder in GameData.player2CardOrder)
        {
            for (int x = 0; x < 3; x++)
            {
                if (tempCardInOrder == (AttackType)x)
                {
                    count[x]--;
                }
            }
        }
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < count[x]; y++)
            {
                GameData.player2CardLastRound.Add((AttackType)x);
            }
        }

    }

    //this will get the cardOrder and delete them from the card left
    // one function for two player

    public void DeleteAllCard()
    {
        for(int x=0; x < transform.childCount ; x++)
        {
            Destroy(transform.GetChild(x).gameObject);
        }
    }
    public void SpawnDeck(int playerNumber)
    {
        List<AttackType> tempDeck = GameData.GetPlayerCardList(playerNumber);
        for (int x=1; x < tempDeck.Count +1; x++)
        {
            SpawnCard(playerNumber ,x, tempDeck[x-1]);
        }
    }
    // spawn one card depends on the 1-5 car number and the attackType
    private void SpawnCard(int playerNumber ,int cardNumber, AttackType at)
    {
        GameObject tempCard = null;
        if ( at== AttackType.Slash)
        {
            tempCard = Instantiate(slashCard, transform.position, transform.rotation, gameObject.transform);
        }
        else if(at == AttackType.Sneak)
        {
            tempCard = Instantiate(sneakCard, transform.position, transform.rotation, gameObject.transform);
        }
        else if (at == AttackType.Counter)
        {
            tempCard = Instantiate(counterCard, transform.position, transform.rotation, gameObject.transform);
        }
        Drag tempDrag = tempCard.GetComponent<Drag>();
        tempDrag.DragToObject = Slots;
        tempDrag.Deck = Deck;
        tempDrag.attackType = at;
        tempDrag.playerNum =playerNumber;
        tempDrag.cardNumber = cardNumber;
        tempDrag.Fold = Fold;
        tempCard.GetComponent<RectTransform>().anchoredPosition= Deck.transform.Find(String.Format("deck{0}", cardNumber)).GetComponent<RectTransform>().anchoredPosition;
    }
}
