using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    public PlayerData PlayerData => _playerData;
    public float Health { get; private set; }

    private void Awake()
    {
        Health = PlayerData.MaxHealth;
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
        }
        else
        {
            Health = 0f;
        }
    }

    private void Heal()
    {
        int health = 10;

        if (Health + health <= PlayerData.MaxHealth)
        {
            Health += health;
        }
    }
}
