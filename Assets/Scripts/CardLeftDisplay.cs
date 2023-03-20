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

    public void UpdateCardLeftDisplay()
    {
        foreach (CardLeft card in cards_P1)
        {
            Destroy(card.cardObject);
        }
        foreach (CardLeft card in cards_P2)
        {
            Destroy(card.cardObject);
        }
        cards_P1.Clear();
        cards_P2.Clear();

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

    public void UpdateCardColorDisplay()
    {
        int green_slash_P1 = 0;
        int green_counter_P1 = 0;
        int green_sneak_P1 = 0;
        int green_slash_P2 = 0;
        int green_counter_P2 = 0;
        int green_sneak_P2 = 0;

        foreach (AttackType type in GameData.player1CardList)
        {
            if (type == AttackType.Slash)
            {
                green_slash_P1++;
            }
            if (type == AttackType.Counter)
            {
                green_counter_P1++;
            }
            if (type == AttackType.Sneak)
            {
                green_sneak_P1++;
            }
        }
        foreach (AttackType type in GameData.player2CardList)
        {
            if (type == AttackType.Slash)
            {
                green_slash_P2++;
            }
            if (type == AttackType.Counter)
            {
                green_counter_P2++;
            }
            if (type == AttackType.Sneak)
            {
                green_sneak_P2++;
            }
        }

        foreach (CardLeft card in cards_P1)
        {
            if (card.attackType == AttackType.Slash && green_slash_P1 > 0)
            {
                card.cardObject.GetComponent<Image>().color = Color.green;
                green_slash_P1--;
            }
            if (card.attackType == AttackType.Counter && green_counter_P1 > 0)
            {
                card.cardObject.GetComponent<Image>().color = Color.green;
                green_counter_P1--;
            }
            if (card.attackType == AttackType.Sneak && green_sneak_P1 > 0)
            {
                card.cardObject.GetComponent<Image>().color = Color.green;
                green_sneak_P1--;
            }
        }
        foreach (CardLeft card in cards_P2)
        {
            if (card.attackType == AttackType.Slash && green_slash_P2 > 0)
            {
                card.cardObject.GetComponent<Image>().color = Color.green;
                green_slash_P2--;
            }
            if (card.attackType == AttackType.Counter && green_counter_P2 > 0)
            {
                card.cardObject.GetComponent<Image>().color = Color.green;
                green_counter_P2--;
            }
            if (card.attackType == AttackType.Sneak && green_sneak_P2 > 0)
            {
                card.cardObject.GetComponent<Image>().color = Color.green;
                green_sneak_P2--;
            }
        }
    }
}
