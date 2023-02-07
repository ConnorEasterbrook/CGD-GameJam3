using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject image;
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
        yield return new WaitForSeconds(5f);
        image.SetActive(true);
    }
}
