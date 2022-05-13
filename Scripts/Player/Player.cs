using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private HealthBar _healthBar;
    
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage();
            print("Damage");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Heal();
            print("Heal");
        }
    }

    private void TakeDamage()
    {
        int damage = 10;

        if (_currentHealth - damage > 0)
        {
            _currentHealth -= damage;
            _healthBar.SetHealth(_currentHealth);
        }        
    }

    private void Heal()
    {
        int health = 10;

        if (_currentHealth + health <= _maxHealth)
        {
            _currentHealth += health;
            _healthBar.SetHealth(_currentHealth);
        }
    }
}
