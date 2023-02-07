using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;
    public bool isAttacking = false;
    private EnemyReceiveAttack _enemyReceiveAttack;
    [SerializeField] private ResourceScript _resourceScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && isAttacking)
        {
            _enemyReceiveAttack = other.gameObject.GetComponent<EnemyReceiveAttack>();
            _enemyReceiveAttack.ReceiveDamage(_damage);
            isAttacking = false;
        }
        else if (other.gameObject.tag == "Root" && isAttacking)
        {
            _resourceScript.woodAmount += 10;
            isAttacking = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && isAttacking)
        {
            _enemyReceiveAttack = other.gameObject.GetComponent<EnemyReceiveAttack>();
            _enemyReceiveAttack.ReceiveDamage(_damage);
            isAttacking = false;
        }
        else if (other.gameObject.tag == "Root" && isAttacking)
        {
            _resourceScript.woodAmount += 10;
            if (other.gameObject.GetComponent<EnemyReceiveAttack>())
            {
                _enemyReceiveAttack = other.gameObject.GetComponent<EnemyReceiveAttack>();
                _enemyReceiveAttack.ReceiveDamage(_damage);
            }
            isAttacking = false;
        }
    }
}
