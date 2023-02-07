using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurretShoot : MonoBehaviour
{
    public GameObject bullet;
    private GameObject _target;
    private List<GameObject> _enemiesInRange;
    [SerializeField] private float _fireRatePerSecond = 1f;
    [SerializeField] private float _range = 10f;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _bulletSpeed = 10f;
    public int ammo = 100;
    [SerializeField] private TextMeshProUGUI _ammoText;
    public bool _isPlaced = false;
    [HideInInspector] public int buildStrikes = 0;
    [SerializeField] private bool _forceShoot = false;

    // Sound
    public AudioSource audioSource;
    [SerializeField] private AudioClip _shootSound;
    public AudioClip reloadSound;
    [SerializeField] private AudioClip _emptySound;
    public AudioClip buildSound;
    [SerializeField] private AudioClip _buildCompleteSound;
    [SerializeField] private AudioClip _idleSound;


    // Start is called before the first frame update
    void Start()
    {
        _enemiesInRange = new List<GameObject>();
        GetComponent<SphereCollider>().radius = _range / 10;

        _ammoText = transform.GetComponentInChildren<TextMeshProUGUI>();

        if (_forceShoot)
        {
            buildStrikes = 3;
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1;

        StartCoroutine(ShootAtEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        // Set target to the closest enemy
        GetClosestEnemy();

        if (buildStrikes >= 3)
        {
            // Update ammo text
            _ammoText.text = ammo.ToString();

            // Play buildcomplete sound
            audioSource.PlayOneShot(_buildCompleteSound);
        }
        else
        {
            _ammoText.text = buildStrikes + "/3";
        }
    }

    private void GetClosestEnemy()
    {
        if (_enemiesInRange.Count == 0)
        {
            _target = null;
            return;
        }

        // Create an array of all the enemies within sphere collider
        float distanceToClosestEnemy = Mathf.Infinity;

        for (int i = 0; i < _enemiesInRange.Count; i++)
        {
            if (_enemiesInRange[i] == null)
            {
                _enemiesInRange.RemoveAt(i);
                continue;
            }

            // If there are enemies in range then shoot at the closest
            if (Vector3.Distance(transform.position, _enemiesInRange[i].transform.position) <= _range)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, _enemiesInRange[i].transform.position);

                if (distanceToEnemy < distanceToClosestEnemy)
                {
                    distanceToClosestEnemy = distanceToEnemy;
                    _target = _enemiesInRange[i];
                }
            }
        }
    }

    private IEnumerator ShootAtEnemy()
    {
        while (true)
        {
            if (_target != null && _isPlaced && buildStrikes >= 3)
            {
                if (ammo <= 0)
                {
                    // Play empty sound
                    audioSource.PlayOneShot(_emptySound);
                }
                else if (ammo > 0)
                {
                    GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
                    newBullet.AddComponent<DestroyOnCollision>();
                    Vector3 direction = (_target.transform.position - transform.position).normalized;
                    Physics.IgnoreCollision(newBullet.GetComponent<Collider>(), GetComponent<Collider>());
                    newBullet.GetComponent<Rigidbody>().AddForce(direction * (_bulletSpeed * 100));

                    _target.GetComponent<EnemyReceiveAttack>().ReceiveDamage(_damage);

                    ammo--;

                    // Play shoot sound
                    audioSource.PlayOneShot(_shootSound);
                }
            }
            else
            {
                int rand = Random.Range(0, 10);
                if (rand == 0)
                {
                    audioSource.PlayOneShot(_idleSound);
                }
            }

            float waitTime = 1f / _fireRatePerSecond;
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void CopyTurret(TurretShoot turret)
    {
        bullet = turret.bullet;
        _fireRatePerSecond = turret._fireRatePerSecond;
        _range = turret._range;
        _damage = turret._damage;
        _bulletSpeed = turret._bulletSpeed;
        ammo = 100;
        _isPlaced = true;

        // Copy sounds
        _shootSound = turret._shootSound;
        reloadSound = turret.reloadSound;
        _emptySound = turret._emptySound;
        buildSound = turret.buildSound;
        _buildCompleteSound = turret._buildCompleteSound;
        _idleSound = turret._idleSound;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _enemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _enemiesInRange.Remove(other.gameObject);
        }
    }
}
