using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillValue : MonoBehaviour
{
    private bool _isTriggered;
    [SerializeField] private ResourceScript _resourceScript;

    private void Update()
    {
        if (_isTriggered)
        {
            // if (Input.GetKey(KeyCode.E) && _resourceScript.ammoAmount < 200 && transform.tag != "Root")
            if (Input.GetKey(KeyCode.E) && _resourceScript.ammoAmount < 200)
            {
                _resourceScript.ammoAmount++;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isTriggered = false;
        }
    }
}
