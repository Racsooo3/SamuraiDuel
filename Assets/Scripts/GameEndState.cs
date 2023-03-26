using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameEndState : GameBaseState
{

    public override void EnterState(GameStateManager game)
    {
        GameObject.Find("/Canvas").GetComponent<Canvas>().enabled=false;
        GameObject.Find("/WinLoseCanvas").GetComponent<Canvas>().enabled = true;
        TextMeshProUGUI Text = GameObject.Find("/WinLoseCanvas/WinText").GetComponent<TextMeshProUGUI>();
        Debug.Log("EndState");
        int P1_final_score = GameData.player1Dominates;
        int P2_final_score = GameData.player2Dominates;

        if (P1_final_score > P2_final_score)
        {
            Text.text = "Player 1 Wins !!!";
            Debug.Log("P1 wins");
        } 
        else if (P2_final_score > P1_final_score)
        {
            Text.text = "Player 2 Wins !!!";
            Debug.Log("P2 wins");
        } else
        {
            Text.text = "Draw !!!";
            Debug.Log("Draw");
        }
        GameObject.Find("/WinLoseCanvas/ReturnGame").GetComponent<Button>().onClick.AddListener(() => {
            SceneManager.LoadScene("MainMenu");
        });
    }

    public override void UpdateState(GameStateManager game)
    {

    }
}
