using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundDisplay : MonoBehaviour
{
    private TextMeshProUGUI roundText;
    void Start()
    {
        roundText = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void RoundTextDisplay(int roundNum)
    {
        roundText.text = "Round " + roundNum;
    }
}
