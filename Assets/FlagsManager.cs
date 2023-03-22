using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagsManager : MonoBehaviour
{
    [SerializeField] GameObject flag;
    [SerializeField] float flagSeperation;

    public void SetFlag(string RedOrBlue, int amountOfFlags)
    {
        if (RedOrBlue == "red")
        {
            for (int i = 0; i< amountOfFlags; i++)
            {
                GameObject f = Instantiate(flag, GameObject.Find("RedFlag").transform);
                f.GetComponent<RectTransform>().anchoredPosition += new Vector2(i * flagSeperation, 0);
            }
        } 
        else if (RedOrBlue == "blue")
        {
            for (int i = 0; i < amountOfFlags; i++)
            {
                GameObject f = Instantiate(flag, GameObject.Find("BlueFlag").transform);
                f.GetComponent<RectTransform>().anchoredPosition += new Vector2(i * -flagSeperation, 0);
            }
        }
        else
        {
            Debug.LogError("There is no such color.");
        }
    }
}
