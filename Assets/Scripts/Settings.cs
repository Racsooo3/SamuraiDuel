using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [Header("Place your settings file here")]
    [SerializeField] private SettingScriptableObject settingSO;

    private float eachRoundTimer;

    void Awake()
    {
        UpdateSettingsFromSO();
    }

    public float GetEachRoundTimer()
    {
        return eachRoundTimer;
    }
    void UpdateSettingsFromSO()
    {
        eachRoundTimer = settingSO.eachRoundTimer;
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
