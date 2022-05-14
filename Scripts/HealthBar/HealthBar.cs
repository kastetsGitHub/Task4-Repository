using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private float _speedOfFill;

    private void Start()
    {  
        SetMaxHealth();
    }

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _player.Health, _speedOfFill * Time.deltaTime);
    }

    private void SetMaxHealth()
    {
        _slider.maxValue = _player.PlayerData.MaxHealth;
        _slider.value = _player.Health;
    }
}
