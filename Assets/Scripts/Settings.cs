using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [Header("Place your settings file here")]
    [SerializeField] private SettingScriptableObject settingSO;

    public float GetEachRoundTimer()
    {
        Debug.Log(settingSO.waitingTime);
        return settingSO.waitingTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            print(" 1: "+ GameData.GetPlayerCardLeft(1)[0] + " " + GameData.GetPlayerCardLeft(1)[1] + " " + GameData.GetPlayerCardLeft(1)[2]);
            print(" 2: "+ GameData.GetPlayerCardLeft(2)[0] + " " + GameData.GetPlayerCardLeft(2)[1] + " " + GameData.GetPlayerCardLeft(2)[2]);
        }
    }
}
