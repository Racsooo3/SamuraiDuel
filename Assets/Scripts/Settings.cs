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
}
