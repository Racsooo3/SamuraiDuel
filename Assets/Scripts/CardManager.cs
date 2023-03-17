using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Slots;
    [SerializeField] private GameObject Deck;
    [SerializeField] private GameObject slashCard;
    [SerializeField] private GameObject sneakCard;
    [SerializeField] private GameObject counterCard;
    private void Start()
    {
        UnityEngine.Debug.Log("testing spawn card, delete this start if not want test");
        GameData.player1CardList =new List <AttackType>{ AttackType.Counter,AttackType.Sneak};
        SpawnDeck(1);
    }
    // this delete all child card under the card manager
    public void DeleteAllCard()
    {
        for(int x=0; x < transform.childCount ; x++)
        {
            Destroy(transform.GetChild(x).gameObject);
        }
    }
    public void SpawnDeck(int playerNumber)
    {
        List<AttackType> tempDeck = null;
        if (playerNumber == 1)
        {
            tempDeck = GameData.player1CardList;
        }
        else
        {
            tempDeck = GameData.player2CardList;
        }
        for (int x=1; x < tempDeck.Count +1; x++)
        {
            SpawnCard(x, tempDeck[x-1]);
        }
    }
    // spawn one card depends on the 1-5 car number and the attackType
    private void SpawnCard(int cardNumber, AttackType at)
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
        tempCard.GetComponent<RectTransform>().anchoredPosition= Deck.transform.Find(String.Format("deck{0}", cardNumber)).GetComponent<RectTransform>().anchoredPosition;
    }
}
