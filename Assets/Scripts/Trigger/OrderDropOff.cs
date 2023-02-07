using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderDropOff : MonoBehaviour
{
    public Image fadeImage;
    public Animator anim;
    public GameObject[] currentOrder;
    public GameObject[] currentFulfilment;
    public int orderCorrect;
    public bool orderComplete;
    public LayerMask pickup;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == 6)
        {
            for (int i = 0; i < currentOrder.Length; i++)
            {
                Debug.Log(other.gameObject.name);
                if (other.gameObject.name == currentOrder[i].name)
                {
                    //currentOrder[i] = null;
                    currentFulfilment[i] = other.gameObject;
                }
            }
        }
    }


    private void Update()
    {
        if (orderCorrect == currentFulfilment.Length)
        {
            orderComplete = true;

            if (orderComplete)
            {
                anim.SetBool("FadeIn", true);
            }
        }

        if (orderComplete != true)
        {
            for (int i = 0; i < currentOrder.Length; i++)
            {
                if (currentOrder[i].name == currentFulfilment[i].name)
                {
                    orderCorrect += 1;
                }
            }
        }
    }
}

