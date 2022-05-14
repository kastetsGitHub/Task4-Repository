using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private float _maxHealth;

    public float MaxHealth => _maxHealth;
}