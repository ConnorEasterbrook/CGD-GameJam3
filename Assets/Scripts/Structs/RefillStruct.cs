using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillStruct : MonoBehaviour
{
    private TurretShoot _turretShoot;
    private bool _isBuilding = false;

    private void Start()
    {
        _turretShoot = GetComponentInParent<TurretShoot>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isBuilding = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) && _turretShoot.ammo < 100)
            {
                other.GetComponent<ResourceScript>().ammoAmount--;
                _turretShoot.ammo++;
            }
        }

        if (other.gameObject.tag == "Tool" && _isBuilding)
        {
            GetComponentInParent<TurretShoot>().buildStrikes++;
            _isBuilding = false;
        }
    }
}
