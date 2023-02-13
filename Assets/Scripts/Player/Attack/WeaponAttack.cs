using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;
    public bool isAttacking = false;
    public bool isInContact = false;
    private EnemyReceiveAttack _enemyReceiveAttack;
    [SerializeField] private ResourceScript _resourceScript;
    [SerializeField] private bool _isResourceGatherer = false;

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "Enemy")
    //     {
    //         isInContact = true;

    //         if (isAttacking)
    //         {
    //             _enemyReceiveAttack = other.gameObject.GetComponent<EnemyReceiveAttack>();
    //             _enemyReceiveAttack.ReceiveDamage(_damage);
    //             isAttacking = false;
    //         }
    //     }
    //     else if (other.gameObject.tag == "Root")
    //     {
    //         if (_isResourceGatherer)
    //         {
    //             GatherResources(other);
    //         }

    //         if (other.gameObject.GetComponent<EnemyReceiveAttack>())
    //         {
    //             _enemyReceiveAttack = other.gameObject.GetComponent<EnemyReceiveAttack>();
    //             _enemyReceiveAttack.ReceiveDamage(_damage);
    //         }
    //     }
    //     else if (other.gameObject.tag == "Struct")
    //     {
    //         BuildStructure(other);
    //     }
    // }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            isInContact = true;

            if (isAttacking)
            {
                _enemyReceiveAttack = other.gameObject.GetComponent<EnemyReceiveAttack>();
                _enemyReceiveAttack.ReceiveDamage(_damage);
                isAttacking = false;
            }
        }
        else if (other.gameObject.tag == "Root")
        {
            if (isAttacking)
            {
                if (other.gameObject.GetComponent<EnemyReceiveAttack>())
                {
                    _enemyReceiveAttack = other.gameObject.GetComponent<EnemyReceiveAttack>();
                    _enemyReceiveAttack.ReceiveDamage(_damage);
                }
                else if (other.gameObject.GetComponentInParent<EnemyReceiveAttack>())
                {
                    _enemyReceiveAttack = other.gameObject.GetComponentInParent<EnemyReceiveAttack>();
                    _enemyReceiveAttack.ReceiveDamage(_damage);
                }
            }

            if (_isResourceGatherer)
            {
                GatherResources(other);
            }
        }
        else if (other.gameObject.tag == "Struct")
        {
            if (!_isResourceGatherer)
            {
                BuildStructure(other);
            }
        }
    }

    private void GatherResources(Collider other)
    {
        isInContact = true;

        if (isAttacking)
        {
            if (_resourceScript.woodAmount < _resourceScript.woodMaxAmount)
            {
                _resourceScript.woodAmount += 10;
            }

            isAttacking = false;
        }
    }

    private void BuildStructure(Collider other)
    {
        isInContact = true;

        // if (other.GetComponent<RefillStruct>().isInContact)
        // {
        if (isAttacking)
        {
            other.GetComponent<RefillStruct>().BuildStrike();
            isAttacking = false;
        }
        // }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            isInContact = false;
        }
        else if (other.gameObject.tag == "Root")
        {
            isInContact = false;
        }
    }
}
