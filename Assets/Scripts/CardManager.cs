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
    /*private void Start()
    {
        UnityEngine.Debug.Log("testing spawn card, delete this start if not want test");
        GameData.player1CardList =new List <AttackType>{ AttackType.Counter,AttackType.Sneak};
        SpawnDeck(1);
    }*/
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
        tempCard.GetComponent<RectTransform>().anchoredPosition= Deck.transform.Find(String.Format("deck{0}", cardNumber)).GetComponent<RectTransform>().anchoredPosition;
    }
}
