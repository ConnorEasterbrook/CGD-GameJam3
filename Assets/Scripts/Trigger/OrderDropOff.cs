using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderDropOff : MonoBehaviour
{
    public GameObject placeObjectText;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            placeObjectText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            placeObjectText.SetActive(false);
        }
    }
}
