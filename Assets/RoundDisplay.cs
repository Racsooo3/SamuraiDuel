using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundDisplay : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI roundText;
    public void RoundTextDisplay(int roundNum)
    {
        roundText.text = "Round " + roundNum;
    }
}
