using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAfterSceneChange : MonoBehaviour
{
    [SerializeField] private IntroOfficeAnimControl _introOfficeAnimControlScript;
    [SerializeField] private GameObject _objectToEnable;
    [SerializeField] private GameObject _objectToDisable;
    [SerializeField] private IntroText _introTextScript;

    // Awake is called before Start
    void Awake()
    {
        if (!_introOfficeAnimControlScript.GetIsIntro())
        {
            _objectToDisable.SetActive(false);
            _objectToEnable.SetActive(true);
            _introTextScript.enabled = false;
        }

        // Disable fog
        RenderSettings.fog = false;
    }
}
