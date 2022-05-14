using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private float _speedOfFill;

    private bool _isAdjust;

    private void OnEnable()
    {
        _player.HealthChanged += SetHealth;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= SetHealth;
    }

    private void Start()
    {
        _isAdjust = true;       
        SetMaxHealth();
    }

    private void SetMaxHealth()
    {
        _slider.maxValue = _player.PlayerData.MaxHealth;
        _slider.value = _player.Health;
    }

    private void SetHealth()
    {
        if (_isAdjust)
        {
            StartCoroutine(AdjustingFill());
        }
    }

    private IEnumerator AdjustingFill()
    {
        _isAdjust = false;

        while (Mathf.Abs(_player.Health - _slider.value) > .00001f)  
        {
            AdjustFill();
            yield return null;
        }      
        
        void AdjustFill()
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _player.Health, _speedOfFill * Time.deltaTime);
        }

        _isAdjust = true;
    }
}
