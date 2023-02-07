using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private Slider _healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        _healthSlider.maxValue = _maxHealth;
        _healthSlider.value = _health;
    }

    // Update is called once per frame
    void Update()
    {
        _healthSlider.value = _health;

        // Lerp the color of the health bar based on the health
        _healthSlider.fillRect.GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, _health / _maxHealth);

        // Regenerate health
        if (_health < _maxHealth)
        {
            _health += 0.1f;
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= (damage / 10);
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
