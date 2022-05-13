using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<float> OnChangedHealth; 
    public float Health { get; private set; }
    public float MaxHealth => _maxHealth;

    [SerializeField] private float _maxHealth;

    private void Start()
    {
        Health = _maxHealth;
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

        if (Health - damage > 0)
        {
            Health -= damage;
            OnChangedHealth?.Invoke(Health);
        }
        else
        {
            Health = 0f;
            OnChangedHealth?.Invoke(Health);
        }
    }

    private void Heal()
    {
        int health = 10;

        if (Health + health <= _maxHealth)
        {
            Health += health;
            OnChangedHealth?.Invoke(Health);
        }
    }
}
