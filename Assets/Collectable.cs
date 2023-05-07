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
            FindObjectOfType<EnemyScript>().aggression += 1;
            nexttextobj.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}


