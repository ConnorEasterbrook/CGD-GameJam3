//using System;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;

    private Rigidbody VegetableRigidbody;
    private Collider VegetableCollider;
    private AudioSource noise;
    public AudioClip[] splashNoises;
    [SerializeField] private ParticleSystem juiceEffect;
    public int points = 1;

    private void Awake()
    {
        VegetableRigidbody = GetComponent<Rigidbody>();
        VegetableCollider = GetComponent<Collider>();
        juiceEffect = GetComponentInChildren<ParticleSystem>();
        noise = GetComponent<AudioSource>();
    }

    private void Slice(Vector3 direction, Vector3 position, float force)
    {
       FindObjectOfType<GameManager>().IncreaseScore(points);

        // Disable the whole Vegetable
        VegetableCollider.enabled = false;
        whole.SetActive(false);

        // Enable the sliced Vegetable
        sliced.SetActive(true);

        // Rotate based on the slice angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();

        noise.clip = splashNoises[Random.Range(0, splashNoises.Length)];
        noise.Play();
        // Add a force to each slice based on the blade direction
        foreach (Rigidbody slice in slices)
        {
            slice.velocity = VegetableRigidbody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
            juiceEffect.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Blade blade = other.GetComponent<Blade>();
            Slice(blade.direction, blade.transform.position, blade.sliceForce);
        }
    }

}