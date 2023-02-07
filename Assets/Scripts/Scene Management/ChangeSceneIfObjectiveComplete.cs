using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneIfObjectiveComplete : MonoBehaviour
{
    [SerializeField] private GameObject _objective;

    // Update is called once per frame
    void Update()
    {
        if (_objective == null)
        {
            SceneManager.LoadScene(0);
        }
    }
}
