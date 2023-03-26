using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [Header("Place your settings file here")]
    [SerializeField] private SettingScriptableObject settingSO;

    public float GetEachRoundTimer()
    {
        //Debug.Log(settingSO.waitingTime);
        return settingSO.waitingTime;
    }

    public int GetTotalRounds()
    {
        //Debug.Log(settingSO.rounds);
        return settingSO.rounds;
    }

    public bool GetEyeHelper()
    {
        //Debug.Log(settingSO.eyeHelper);
        return settingSO.eyeHelper;
    }
}
