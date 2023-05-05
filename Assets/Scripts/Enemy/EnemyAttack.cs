using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private PlayerScript _playerScript;
    private HealthScript _healthScript;
    private BoxCollider _enemyTarget;
    [SerializeField] private float _damage = 10f;
    private Rigidbody _rigidbody;
    private bool _inAttackRange = false;
    public bool isAttacking = false;
    [SerializeField] private float _speed = 2f;
    private Animator _animator;
    private int _randTarget;
    private bool _isAttackingPlayer = false;
    [SerializeField] AudioSource attackSound;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        _healthScript = _playerScript.GetComponent<HealthScript>();
        GameObject[] targetList = GameObject.FindGameObjectsWithTag("EnemyTarget");

        // Get a random number between 0 and the length of the object list
        _randTarget = Random.Range(0, targetList.Length);
        _enemyTarget = targetList[_randTarget].GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerScript == null)
        {
            return;
        }
        
        if (!_inAttackRange)
        {
            Vector3 vel = transform.forward * _speed;
            vel.y = _rigidbody.velocity.y;
            _rigidbody.velocity = vel;

            _animator.SetBool("IsMoving", true);

            PrimaryFocus();
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void PrimaryFocus()
    {
        // If the player is close to the spider then focus on the player using Distance
        if (Vector3.Distance(transform.position, _playerScript.transform.position) < 10f)
        {
            transform.LookAt(_playerScript.transform.position);
        }
        else
        {
            Vector3 targetPos = new Vector3(_enemyTarget.bounds.center.x, transform.position.y, _enemyTarget.bounds.center.z);
            transform.LookAt(targetPos);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _inAttackRange = true;
            _animator.SetBool("IsMoving", false);

            _healthScript.TakeDamage(_damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _inAttackRange = true;
            _animator.SetBool("IsMoving", false);
            attackSound.Play();
            _healthScript.TakeDamage(_damage);
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
