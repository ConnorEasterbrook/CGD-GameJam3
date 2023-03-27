using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyReceiveAttack : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _currentHealth = 100f;
    [SerializeField] private float _armourLevel = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // _healthBar.maxValue = _maxHealth;
        _healthBar.value = _maxHealth;
    }

    void Update()
    {
        // Set the normal colour of the slider to Lerp based on health
        _healthBar.fillRect.GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, _healthBar.normalizedValue);
    }

    public void ReceiveDamage(float damage)
    {
        Debug.Log("Enemy took " + damage + " damage");
        _currentHealth -= (damage / _armourLevel);
        _healthBar.value = _currentHealth / _maxHealth;
        if (_healthBar.value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
