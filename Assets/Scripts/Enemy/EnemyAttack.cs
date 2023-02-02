using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private PlayerScript _playerScript;
    [SerializeField] private float _damage = 10f;
    private Rigidbody _rigidbody;
    private bool _inAttackRange = false;
    public bool isAttacking = false;
    [SerializeField] private float _speed = 2f;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!_inAttackRange)
        {
            _rigidbody.velocity = transform.forward * _speed;
            _animator.SetBool("IsMoving", true);

            // LookAt the player but only rotate on y axis
            Vector3 targetPosition = new Vector3(_playerScript.transform.position.x, transform.position.y, _playerScript.transform.position.z);
            transform.LookAt(targetPosition);
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _inAttackRange = true;
            _animator.SetBool("IsMoving", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _inAttackRange = true;
            _animator.SetBool("IsMoving", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _inAttackRange = false;
            _animator.SetBool("IsMoving", true);
        }
    }
}
