using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardLeftDisplay : MonoBehaviour
{
    [Header("Cards Prefeb")]
    [SerializeField] GameObject slash_card;
    [SerializeField] GameObject counter_card;
    [SerializeField] GameObject sneak_card;

    List<CardLeft> cards_P1 = new List<CardLeft>();
    List<CardLeft> cards_P2 = new List<CardLeft>();

    [Header("Instantiate Transforms")]
    [SerializeField] Transform player1_slash_pos;
    [SerializeField] Transform player1_counter_pos;
    [SerializeField] Transform player1_sneak_pos;

    [SerializeField] Transform player2_slash_pos;
    [SerializeField] Transform player2_counter_pos;
    [SerializeField] Transform player2_sneak_pos;

    [SerializeField] float CardSpacing;

    private void Start()
    {
        player1_slash_pos = transform.GetChild(0).transform;
        player1_counter_pos = transform.GetChild(1).transform;
        player1_sneak_pos = transform.GetChild(2).transform;
        player2_slash_pos = transform.GetChild(3).transform;
        player2_counter_pos = transform.GetChild(4).transform;
        player2_sneak_pos = transform.GetChild(5).transform;
    }

    private void RemoveAllDisplayCards()
    {
        //remove all previous card displays and the array list
        foreach (CardLeft card in cards_P1)
        {
            Destroy(card.cardObject);
        }
        foreach (CardLeft card in cards_P2)
        {
            Destroy(card.cardObject);
        }
    }

    private void DisplayCardsLeft()
    {
        // Add cards distributed by random to the array list and display them
        for (int i = 0; i < GameData.player1SlashLeft; i++)
        {
            CardLeft T = new CardLeft(Instantiate(slash_card, player1_slash_pos), AttackType.Slash);
            cards_P1.Add(T);

            RectTransform rect = T.cardObject.GetComponent<RectTransform>();
            rect.anchoredPosition += new Vector2(-CardSpacing * i, 0);
        }
        for (int i = 0; i < GameData.player1CounterLeft; i++)
        {
            CardLeft T = new CardLeft(Instantiate(counter_card, player1_counter_pos), AttackType.Counter);
            cards_P1.Add(T);

            RectTransform rect = T.cardObject.GetComponent<RectTransform>();
            rect.anchoredPosition += new Vector2(-CardSpacing * i, 0);
        }
        for (int i = 0; i < GameData.player1SneakLeft; i++)
        {
            CardLeft T = new CardLeft(Instantiate(sneak_card, player1_sneak_pos), AttackType.Sneak);
            cards_P1.Add(T);

            RectTransform rect = T.cardObject.GetComponent<RectTransform>();
            rect.anchoredPosition += new Vector2(-CardSpacing * i, 0);
        }
        for (int i = 0; i < GameData.player2SlashLeft; i++)
        {
            CardLeft T = new CardLeft(Instantiate(slash_card, player2_slash_pos), AttackType.Slash);
            cards_P2.Add(T);

            RectTransform rect = T.cardObject.GetComponent<RectTransform>();
            rect.anchoredPosition += new Vector2(CardSpacing * i, 0);
        }
        for (int i = 0; i < GameData.player2CounterLeft; i++)
        {
            CardLeft T = new CardLeft(Instantiate(counter_card, player2_counter_pos), AttackType.Counter);
            cards_P2.Add(T);

            RectTransform rect = T.cardObject.GetComponent<RectTransform>();
            rect.anchoredPosition += new Vector2(CardSpacing * i, 0);
        }
        for (int i = 0; i < GameData.player2SneakLeft; i++)
        {
            CardLeft T = new CardLeft(Instantiate(sneak_card, player2_sneak_pos), AttackType.Sneak);
            cards_P2.Add(T);

            RectTransform rect = T.cardObject.GetComponent<RectTransform>();
            rect.anchoredPosition += new Vector2(CardSpacing * i, 0);
        }
    }

    private void DisplayCardsLastRound()
    {
        int[] cardLastRound_P1 = new int[3] { 0, 0, 0 }; // Stored order {slash, counter, sneak}
        int[] cardLastRound_P2 = new int[3] { 0, 0, 0 }; // Stored order {slash, counter, sneak}
        // Add cards left from last round and display them.
        foreach (AttackType type in GameData.player1CardLastRound)
        {
            switch (type)
            {
                case AttackType.Slash:
                    cardLastRound_P1[0]++;
                    break;
                case AttackType.Counter:
                    cardLastRound_P1[1]++;
                    break;
                case AttackType.Sneak:
                    cardLastRound_P1[2]++;
                    break;
            }
        }
        foreach (AttackType type in GameData.player2CardLastRound)
        {
            switch (type)
            {
                case AttackType.Slash:
                    cardLastRound_P2[0]++;
                    break;
                case AttackType.Counter:
                    cardLastRound_P2[1]++;
                    break;
                case AttackType.Sneak:
                    cardLastRound_P2[2]++;
                    break;
            }
        }

        for (int i = 0; i < cardLastRound_P1[0]; i++)
        {
            CardLeft T = new CardLeft(Instantiate(slash_card, player1_slash_pos), AttackType.Slash);
            cards_P1.Add(T);

            RectTransform rect = T.cardObject.GetComponent<RectTransform>();
            rect.anchoredPosition += new Vector2(-CardSpacing * i + -150f, 0);
        }
        for (int i = 0; i < cardLastRound_P1[1]; i++)
        {
            CardLeft T = new CardLeft(Instantiate(counter_card, player1_counter_pos), AttackType.Counter);
            cards_P1.Add(T);

            RectTransform rect = T.cardObject.GetComponent<RectTransform>();
            rect.anchoredPosition += new Vector2(-CardSpacing * i + -150f, 0);
        }
        for (int i = 0; i < cardLastRound_P1[2]; i++)
        {
            CardLeft T = new CardLeft(Instantiate(sneak_card, player1_sneak_pos), AttackType.Sneak);
            cards_P1.Add(T);

            RectTransform rect = T.cardObject.GetComponent<RectTransform>();
            rect.anchoredPosition += new Vector2(-CardSpacing * i + -150f, 0);
        }
        for (int i = 0; i < cardLastRound_P2[0]; i++)
        {
            CardLeft T = new CardLeft(Instantiate(slash_card, player2_slash_pos), AttackType.Slash);
            cards_P2.Add(T);

            RectTransform rect = T.cardObject.GetComponent<RectTransform>();
            rect.anchoredPosition += new Vector2(CardSpacing * i + 150f, 0);
        }
        for (int i = 0; i < cardLastRound_P2[1]; i++)
        {
            CardLeft T = new CardLeft(Instantiate(counter_card, player2_counter_pos), AttackType.Counter);
            cards_P2.Add(T);

            RectTransform rect = T.cardObject.GetComponent<RectTransform>();
            rect.anchoredPosition += new Vector2(CardSpacing * i + 150f, 0);
        }
        for (int i = 0; i < cardLastRound_P2[2]; i++)
        {
            CardLeft T = new CardLeft(Instantiate(sneak_card, player2_sneak_pos), AttackType.Sneak);
            cards_P2.Add(T);

            RectTransform rect = T.cardObject.GetComponent<RectTransform>();
            rect.anchoredPosition += new Vector2(CardSpacing * i + 150f, 0);
        }
    }

    public void UpdateCardLeftDisplay()
    {
        RemoveAllDisplayCards();
        cards_P1.Clear();
        cards_P2.Clear();

        DisplayCardsLeft();
        DisplayCardsLastRound();
    }

    public void UpdateCardColorDisplay()
    {
        int[] card_P1 = GameData.GetPlayerCardLeft(1);
        int[] card_P2 = GameData.GetPlayerCardLeft(2);
        int green_slash_P1 = card_P1[0];
        int green_counter_P1 = card_P1[2];
        int green_sneak_P1 = card_P1[1];
        int green_slash_P2 = card_P2[0];
        int green_counter_P2 = card_P2[2];
        int green_sneak_P2 = card_P2[1];

        foreach (CardLeft card in cards_P1)
        {
            if (card.attackType == AttackType.Slash && green_slash_P1 > 0)
            {
                card.cardObject.GetComponent<Image>().color = Color.grey;
                green_slash_P1--;
            }
            if (card.attackType == AttackType.Counter && green_counter_P1 > 0)
            {
                card.cardObject.GetComponent<Image>().color = Color.grey;
                green_counter_P1--;
            }
            if (card.attackType == AttackType.Sneak && green_sneak_P1 > 0)
            {
                card.cardObject.GetComponent<Image>().color = Color.grey;
                green_sneak_P1--;
            }
        }
        foreach (CardLeft card in cards_P2)
        {
            if (card.attackType == AttackType.Slash && green_slash_P2 > 0)
            {
                card.cardObject.GetComponent<Image>().color = Color.grey;
                green_slash_P2--;
            }
            if (card.attackType == AttackType.Counter && green_counter_P2 > 0)
            {
                card.cardObject.GetComponent<Image>().color = Color.grey;
                green_counter_P2--;
            }
            if (card.attackType == AttackType.Sneak && green_sneak_P2 > 0)
            {
                card.cardObject.GetComponent<Image>().color = Color.grey;
                green_sneak_P2--;
            }
        }
    }
}
