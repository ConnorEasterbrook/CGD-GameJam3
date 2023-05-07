using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CamTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timer;
    private int hours;
    private int minutes;
    private int seconds;

    void Update()
    {
        timer += Time.deltaTime;

        hours = Mathf.FloorToInt(timer / 3600);
        minutes = Mathf.FloorToInt((timer % 3600) / 60);
        seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
