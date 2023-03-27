using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioSource Playsound;
    public GameObject Textobject;
    public GameObject nexttextobj = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Textobject)
        {
            Playsound.Play();

            nexttextobj.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}


