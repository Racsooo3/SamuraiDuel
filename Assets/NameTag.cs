using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameTag : MonoBehaviour
{
    TextMeshProUGUI text;
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    
    public void ChangeText(string name, Color color)
    {
        this.text.text = name;
        text.color = color;
    }
}
