using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed;
    [SerializeField] private Player _player;

    private Coroutine _coroutine;
    private bool _isAdjust;

    private void Start()
    {
        _isAdjust = true;
        _player.OnChangedHealth += SetHealth;
        SetMaxHealth();
    }

    private void SetMaxHealth()
    {
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _player.Health;
    }

    public void SetHealth(float health)
    {
        if (_isAdjust)
        {
            StartCoroutine(AdjustingFill(health));
        }
    }

    private IEnumerator AdjustingFill(float health)
    {
        _isAdjust = false;

        if (health > _slider.value)
        {
            while (health > _slider.value)
            {
                Adjust();
                yield return null;
            }
        }

        if (health < _slider.value)
        {
            while (health < _slider.value)
            {
                Adjust();
                yield return null;
            }
        }
        
        void Adjust()
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _speed * Time.deltaTime);
        }

        _isAdjust = true;
    }
}
