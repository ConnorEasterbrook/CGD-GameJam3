using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillStruct : MonoBehaviour
{
    private TurretShoot _turretShoot;

    private void Start()
    {
        _turretShoot = GetComponentInParent<TurretShoot>();
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
    }
}
