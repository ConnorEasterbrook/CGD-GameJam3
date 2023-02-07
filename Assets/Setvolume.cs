using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Setvolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void Setlevel(float sliderValue)
    {
        Debug.Log(sliderValue);
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
}
