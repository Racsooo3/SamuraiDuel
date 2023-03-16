using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    string currentState;
    public void ChangeAnimationState(string newState, int PlayerID)
    {
        if (currentState == newState) return;
        currentState = newState;

        // WIP
        if (PlayerID == 1)
        {
            GameObject.Find("Player 1").GetComponent<Animator>().Play(newState);
        }
        else if (PlayerID == 2)
        {
            GameObject.Find("Player 1").GetComponent<Animator>().Play(newState);
        }
        else return;
    }
}
