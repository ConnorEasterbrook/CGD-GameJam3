using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Animations;
using TMPro;

public class JoshSceneManager : MonoBehaviour
{
    public Image FadeImage;
    int dayCounter;
    float minuteCounter;

    public GameObject timerUI;

    public GameObject[] dayObjects;

    void Awake()
    {
        Debug.Log("Script awake");
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }


    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }



    enum Days
    { 
        DAYZERO,
        DAYONE,
        DAYTWO,
        DAYTHREE,
        DAYFOUR
    };

    public void daySwitcher(int dayNumber)
    {
        switch (dayNumber)
        {
            case (int)Days.DAYZERO:
                break;
            case (int)Days.DAYONE:
                dayItemManager((int)Days.DAYONE);
                break;

            case (int)Days.DAYTWO:
                dayItemManager((int)Days.DAYTWO);
                break;

            case (int)Days.DAYTHREE:
                dayItemManager((int)Days.DAYTHREE);
                break;

            case (int)Days.DAYFOUR:
                dayItemManager((int)Days.DAYFOUR);
                break;
        }
    }

    private void Start()
    {
        daySwitcher(0);
    }


    void timerCountdown()
    {
        if (minuteCounter == 0)
        {

        }
    }


    public void dayItemManager(int day)
    {
        for (int i = 0; i < dayObjects.Length; i++)
        {
            dayObjects[i].SetActive(false);
            if (i == day)
            {
                dayObjects[day].SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            dayCounter += 1;
            daySwitcher(dayCounter);
        }
    }
}
