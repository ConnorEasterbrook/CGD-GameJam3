using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderTimer : MonoBehaviour
{
    public float currentTime = 59f;
    public float startingTime = 59f;
    public static bool countDownStarted = false;

   
    public static bool start = false;

    public GameObject gameoverScreen;
    public GameObject timer;
    public TextMeshProUGUI timerUI;

    void resetTimer()
    {
        currentTime = startingTime;
        start = false;
    }

    void timerCountdown()
    {
        if (start)
        {
            timer.SetActive(true);
            if (currentTime <= 0)
            {
                Time.timeScale = 0;
                gameoverScreen.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                countDownStarted = false;
            }

            if (currentTime > 0)
            {
                currentTime -= 1 * Time.deltaTime;

                if (currentTime > 5)
                {
                    timerUI.color = Color.green;
                }

                if (currentTime <= 5)
                {
                    timerUI.color = Color.red;
                }
                timerUI.text = ((int)currentTime).ToString();
            }
        }
    }

    private void Update()
    {
        Debug.Log(start);
        if (JoshSceneManager.dayComplete)
        {
            resetTimer();
            
        }

        timerCountdown();
    }
}
