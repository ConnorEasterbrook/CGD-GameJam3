using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTomain : MonoBehaviour
{
    public GameObject nexttextobj = null;
    private void Update()
    {
        if (nexttextobj.activeSelf == true)
        {
            StartCoroutine(Waitor());
        }

    }

    IEnumerator Waitor()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Core Screen");
    }
}
