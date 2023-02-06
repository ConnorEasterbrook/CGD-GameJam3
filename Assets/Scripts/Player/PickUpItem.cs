using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    GameObject objectFound;
    public GameObject pickUpText;
    public Camera playerCam;
    public LayerMask pickUpLayer;

    void FoundObject()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.TransformDirection(Vector3.forward), out hit, 1, pickUpLayer.value))
        {
            pickUpText.SetActive(true);
        }

        else
        {
            pickUpText.SetActive(false);
        }
    }

    void Update()
    {
        FoundObject();
    }
}
