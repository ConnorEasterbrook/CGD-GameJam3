using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour
{

    [SerializeField] GameObject _Resumebutton, _Backbutton;


    public GameObject _optionsUI;
    [SerializeField] private GameObject _pauseUI;

    public void BackGame()
    {
        Debug.Log("Game Back");
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_Resumebutton);
        _pauseUI.SetActive(true);
        _optionsUI.SetActive(false);
    }
}
