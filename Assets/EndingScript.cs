using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{

    public static bool triggerEnd;
    private void Update()
    {
        if (triggerEnd)
        {
            SceneManager.LoadScene(0);
        }
    }
}
