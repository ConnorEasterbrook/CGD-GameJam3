using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] GameObject pickUpText;
    [SerializeField] Transform holdPosition;
    private GameObject heldObject;
    private Rigidbody rigidObject;
    private float force = 150;

    public Camera playerCam;
    public LayerMask pickUpLayer;
    bool crouching;

    void FoundObject()
    {
        RaycastHit hit;

        if (heldObject == null)
        {
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.TransformDirection(Vector3.forward), out hit, 2, pickUpLayer.value))
            {
                pickUpText.SetActive(true);
                if (Input.GetButtonUp("Interact"))
                {
                    PickUp(hit.transform.gameObject);

                    Debug.Log("Item picked up");
                }
            }
        }

        else
        {
            pickUpText.SetActive(false);
            Move();
            if (Input.GetButtonUp("Interact"))
            {
                Drop();
            }
        }
    }

    void PickUp(GameObject obj)
    {
        if (obj.GetComponent<Rigidbody>())
        {
            rigidObject = obj.GetComponent<Rigidbody>();
            rigidObject.drag = 10;
            rigidObject.useGravity = false;
            rigidObject.constraints = RigidbodyConstraints.FreezeRotation;
            rigidObject.transform.parent = holdPosition;
            heldObject = obj;
        }
    }

    void Drop()
    {
        rigidObject.drag = 1;
        rigidObject.useGravity = true;
        rigidObject.constraints = RigidbodyConstraints.None;
        rigidObject.transform.parent = null;
        heldObject = null;
    }


    void Move()
    {
        if (Vector3.Distance(heldObject.transform.position, holdPosition.position) > 0.1f)
        {
            Vector3 movedir = (holdPosition.position - heldObject.transform.position);

            rigidObject.AddForce(movedir * force);
        }
    }


    void Update()
    {
      
        FoundObject();
    }
}
