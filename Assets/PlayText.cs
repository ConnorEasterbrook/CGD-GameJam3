using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayText : MonoBehaviour
{
    public GameObject Textobject;
    public GameObject nexttextobj = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Textobject)
        {
            nexttextobj.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
