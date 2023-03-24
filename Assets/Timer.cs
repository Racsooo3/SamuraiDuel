using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI time_text;

    // Thank you ChatGPT
    static float[] ConvertSecondsToMinutesAndSeconds(float totalSeconds)
    {
        float minutes = Mathf.FloorToInt(totalSeconds / 60);
        float seconds = totalSeconds % 60;
        float[] timeArray = { minutes, seconds };
        return timeArray;
    }

        public void SetTimeText(float second)
    {
        float[] time = ConvertSecondsToMinutesAndSeconds(second);
        float min = Mathf.Round(time[0]);
        float sec = Mathf.Round(time[1]);

        time_text.text = min + ":" + sec;
    }
}
