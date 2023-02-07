using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{


    private Image batterybar;

    public battery battery;
    // Start is called before the first frame update
    void Start()
    {
        batterybar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        batterybar.fillAmount = battery.m_light.intensity / battery.Maxbightness;
    }
}
