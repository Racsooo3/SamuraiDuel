using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EyeHelper : MonoBehaviour
{
    [SerializeField] GameObject helperOne;
    [SerializeField] GameObject helperTwo;

    [SerializeField] Sprite closedEye;
    [SerializeField] Sprite openedEye;

    bool isVisible;

    const string openEyeText = "please open your eyes and start your move, it's your turn!";
    const string closeEyeText = "please close your eyes if you haven't, it's your opponent's turn!";

    public void PlayersTurn(int OneOrTwo)
    {
        if (!isVisible) return;
        if(OneOrTwo == 1)
        {
            helperOne.GetComponent<Image>().sprite = openedEye;
            helperTwo.GetComponent<Image>().sprite = closedEye;
            helperOne.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Player 1 " + openEyeText;
            helperTwo.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Player 2 " + closeEyeText;
        } else if (OneOrTwo == 2)
        {
            helperOne.GetComponent<Image>().sprite = closedEye;
            helperTwo.GetComponent<Image>().sprite = openedEye;
            helperOne.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Player  " + closeEyeText;
            helperTwo.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Player 2 " + openEyeText;
        }
    }

    public void ShowHelpers(bool show)
    {
        helperOne.SetActive(show);
        helperTwo.SetActive(show);
        isVisible = show;
    }
}
