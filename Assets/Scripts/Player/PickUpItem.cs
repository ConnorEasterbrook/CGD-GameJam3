using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] GameObject pickUpText;
    [SerializeField] Transform holdPosition;
    private GameObject heldObject;
    private Rigidbody rigidObject;
    private float force = 150;

    public static bool allowPickup;

    public Camera playerCam;
    public LayerMask pickUpLayer;
    bool crouching;

    [SerializeField] private Slider _energySlider;
    [Range(0.25f, 1.5f)]
    [SerializeField] private float _playerWeakness = 1.5f; 
    private bool _isHolding;

    void Update()
    {
        FoundObject();

        if (_isHolding)
        {
            _energySlider.value -= _playerWeakness * Time.deltaTime;

            if(_energySlider.value <= 0)
            {
                Drop();
            }
        }
        else
        {
            _energySlider.value += _playerWeakness * Time.deltaTime;
        }

        // Change the slider colour based on the value
        _energySlider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Color.red, Color.green, _energySlider.normalizedValue);
        _energySlider.GetComponentInChildren<Image>().color = Color.Lerp(new Color(1f, 0.5f, 0.5f), new Color(0.5f, 1f, 0.5f), _energySlider.normalizedValue);
    }

    void FoundObject()
    {
        RaycastHit hit;

        if (allowPickup)
        {
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
                else
                {
                    pickUpText.SetActive(false);
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
    }

    void PickUp(GameObject obj)
    {
        if (obj.GetComponent<Rigidbody>())
        {
            _isHolding = true;
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
        _isHolding = false;
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
}
