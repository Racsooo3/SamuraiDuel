using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Players' Reference")]
    public GameObject player1;
    public GameObject player2;

    [Header("Particles")]
    [SerializeField] private GameObject slash_word_effect;
    [SerializeField] private GameObject counter_word_effect;
    [SerializeField] private GameObject sneak_word_effect;

    private Vector3 playerOneOGPos;
    private Vector3 playerTwoOGPos;

    public float anim_count
    {
        get;
        private set;
    }

    public void StartAnimation()
    {
        MoveCloser();
        anim_count = 3f;
        playerOneOGPos = player1.transform.position;
        playerTwoOGPos = player2.transform.position;
    }

    private void MoveCloser()
    {
        if (Vector2.Distance(player1.transform.position, player2.transform.position) > 2.5f)
        {
            ChangeAnimationState_P1("player_walk");
            ChangeAnimationState_P2("player_walk");
            player1.transform.position += new Vector3(0.05f, 0, 0);
            player2.transform.position += new Vector3(-0.05f, 0, 0);

            Invoke("MoveCloser", 0.05f);

        }
        else
        {
            AnimateSlot();
        }
    }

    private void AnimateSlot()
    {
        if (anim_count > 2)
        {
            DetermineMove(GameData.player1CardOrder[0], GameData.player2CardOrder[0]);
            DetermineParticle(GameData.player1CardOrder[0], 1);
            DetermineParticle(GameData.player2CardOrder[0], 2);
            anim_count--;

            Invoke("AnimateSlot", 2);
        } else if (anim_count > 1)
        {
            DetermineMove(GameData.player1CardOrder[1], GameData.player2CardOrder[1]);
            DetermineParticle(GameData.player1CardOrder[1], 1);
            DetermineParticle(GameData.player2CardOrder[1], 2);
            anim_count--;

            Invoke("AnimateSlot", 2);
        } else if (anim_count > 0)
        {
            DetermineMove(GameData.player1CardOrder[2], GameData.player2CardOrder[2]);
            DetermineParticle(GameData.player1CardOrder[2], 1);
            DetermineParticle(GameData.player2CardOrder[2], 2);
            anim_count--;

            Invoke("AnimateSlot", 2);
        } else
        {
            anim_count--;
            ReturnDefault();
        }
    }

    private void ReturnDefault()
    {
        player1.transform.position = playerOneOGPos;
        player2.transform.position = playerTwoOGPos;
        ChangeAnimationState_P2("player_idle");
        ChangeAnimationState_P1("player_idle");
    }


    private void DetermineMove(AttackType attackType_P1, AttackType attackType_P2)
    {
        /*
         * Animation List:
         * player_idle
         * player_walk
         * player_slash
         * player_slash_countered
         * player_counter
         * player_counter_success
         * player_sneak
         * player_sneak_slashed
        */

        switch (attackType_P1)
        {
            case AttackType.Slash:
                switch (attackType_P2)
                {
                    case AttackType.Slash:
                        ChangeAnimationState_P1("player_slash_countered"); 
                        ChangeAnimationState_P2("player_slash_countered"); 
                        break;
                    case AttackType.Counter:
                        ChangeAnimationState_P1("player_slash_countered"); 
                        ChangeAnimationState_P2("player_counter_success");
                        break;
                    case AttackType.Sneak:
                        ChangeAnimationState_P1("player_slash");
                        ChangeAnimationState_P2("player_sneak_slashed");
                        break;
                    case AttackType.Empty:
                        ChangeAnimationState_P1("player_slash");
                        ChangeAnimationState_P2("player_idle");
                        break;
                }
                break;
            case AttackType.Counter:
                switch (attackType_P2)
                {
                    case AttackType.Slash:
                        ChangeAnimationState_P1("player_counter_success");
                        ChangeAnimationState_P2("player_slash_countered");
                        break;
                    case AttackType.Counter:
                        ChangeAnimationState_P1("player_counter");
                        ChangeAnimationState_P2("player_counter");
                        break;
                    case AttackType.Sneak:
                        ChangeAnimationState_P1("player_counter_fail");
                        ChangeAnimationState_P2("player_sneak");
                        break;
                    case AttackType.Empty:
                        ChangeAnimationState_P1("player_counter");
                        ChangeAnimationState_P2("player_idle");
                        break;
                }
                break;
            case AttackType.Sneak:
                switch (attackType_P2)
                {
                    case AttackType.Slash:
                        ChangeAnimationState_P1("player_sneak_slashed");
                        ChangeAnimationState_P2("player_slash");
                        break;
                    case AttackType.Counter:
                        ChangeAnimationState_P1("player_sneak");
                        ChangeAnimationState_P2("player_counter_fail");
                        break;
                    case AttackType.Sneak:
                        ChangeAnimationState_P1("player_sneak_slashed");
                        ChangeAnimationState_P2("player_sneak_slashed");
                        break;
                    case AttackType.Empty:
                        ChangeAnimationState_P1("player_sneak");
                        ChangeAnimationState_P2("player_idle");
                        break;
                }
                break;
            case AttackType.Empty:
                switch (attackType_P2)
                {
                    case AttackType.Slash:
                        ChangeAnimationState_P1("player_idle");
                        ChangeAnimationState_P2("player_slash");
                        break;
                    case AttackType.Counter:
                        ChangeAnimationState_P1("player_idle");
                        ChangeAnimationState_P2("player_counter");
                        break;
                    case AttackType.Sneak:
                        ChangeAnimationState_P1("player_idle");
                        ChangeAnimationState_P2("player_sneak");
                        break;
                    case AttackType.Empty:
                        ChangeAnimationState_P1("player_idle");
                        ChangeAnimationState_P2("player_idle");
                        break;
                }
                break;

        }
    }

    private void DetermineParticle(AttackType attackType, int playerNum)
    {
        GameObject p;
        if (playerNum == 1) // player 1
        {
            p = player1;
        }
        else // player 2
        {
            p = player2;
        }
        Vector3 pos = p.transform.position + new Vector3(0, 1.5f, 0);
        switch (attackType)
        {
            case AttackType.Slash:
                Instantiate(slash_word_effect, pos, Quaternion.identity);
                break;
            case AttackType.Counter:
                
                Instantiate(counter_word_effect, pos, Quaternion.identity);
                break;
            case AttackType.Sneak:
                Instantiate(sneak_word_effect, pos, Quaternion.identity);
                break;
            case AttackType.Empty:
                break;
        }
    }

    string currentState_P1;
    private void ChangeAnimationState_P1(string newState)
    {
        if (currentState_P1 == newState) return;
        currentState_P1 = newState;
        player1.GetComponent<Animator>().Play(newState);
    }

    string currentState_P2;
    private void ChangeAnimationState_P2(string newState)
    {
        if (currentState_P2 == newState) return;
        currentState_P2 = newState;
        player2.GetComponent<Animator>().Play(newState);
    }
}
