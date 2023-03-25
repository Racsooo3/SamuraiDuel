using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGraphicSetting : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Application.targetFrameRate = 39;
    }
}
