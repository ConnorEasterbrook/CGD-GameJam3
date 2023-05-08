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
        if (other.gameObject.layer == 10)
        {
            for (int i = 0; i < currentOrder.Length; i++)
            {
                if (other.gameObject.name == currentOrder[i].name)
                {
                    currentFulfilment[i] = other.gameObject;
                    orderCorrect += 1;
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
                for (int i = 0; i < currentFulfilment.Length; i++)
                {
                    Destroy(currentFulfilment[i].gameObject);
                }
                JoshSceneManager.dayComplete = true;
            }
        }
    }
}

