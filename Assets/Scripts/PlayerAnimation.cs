using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    /// <summary>
    /// Debug Purpose
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MoveCloser();
            DetermineMove(GameData.player1CardOrder[0], 1);
            DetermineMove(GameData.player2CardOrder[0], 2);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            DetermineMove(GameData.player1CardOrder[1], 1);
            DetermineMove(GameData.player2CardOrder[1], 2);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            DetermineMove(GameData.player1CardOrder[2], 1);
            DetermineMove(GameData.player2CardOrder[2], 2);
        }
    }
    /// <summary>
    /// Debug Purpose
    /// </summary>


    public void MoveCloser()
    {
        player1.transform.position += new Vector3(2, 0, 0);
        player2.transform.position += new Vector3(-2, 0, 0);
    }

    public void DetermineMove(AttackType attackType, int playerNum)
    {
        if (playerNum == 1)
        {
            switch (attackType)
            {
                case AttackType.Slash:
                    ChangeAnimationState_P1("player_slash");
                    break;
                case AttackType.Counter:
                    ChangeAnimationState_P1("player_counter");
                    break;
                case AttackType.Sneak:
                    ChangeAnimationState_P1("player_sneak");
                    break;
                case AttackType.Empty:
                    ChangeAnimationState_P1("player_idle");
                    break;
            }
        } else // Player 2
        {
            switch (attackType)
            {
                case AttackType.Slash:
                    ChangeAnimationState_P2("player_slash");
                    break;
                case AttackType.Counter:
                    ChangeAnimationState_P2("player_counter");
                    break;
                case AttackType.Sneak:
                    ChangeAnimationState_P2("player_sneak");
                    break;
                case AttackType.Empty:
                    ChangeAnimationState_P2("player_idle");
                    break;
            }
        }
    }

    string currentState_P1;
    public void ChangeAnimationState_P1(string newState)
    {
        if (currentState_P1 == newState) return;
        currentState_P1 = newState;
        player1.GetComponent<Animator>().Play(newState);
    }

    string currentState_P2;
    public void ChangeAnimationState_P2(string newState)
    {
        if (currentState_P2 == newState) return;
        currentState_P2 = newState;
        player2.GetComponent<Animator>().Play(newState);
    }
}
