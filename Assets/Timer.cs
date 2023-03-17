using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI time_text;
    
    float[] TimeConvert(float second)
    {
        float[] time = new float[2];
        float min = 0;
        time[1] = second % 60;
        while (second/60 > 1)
        {
            min++;
            second /= 60;
        }
        time[0] = min;

        return time;
    }

    public void SetTimeText(float second)
    {
        float[] time = TimeConvert(second);
        float min = Mathf.Round(time[0]);
        float sec = Mathf.Round(time[1]);

        time_text.text = min + ":" + sec;
    }
}
