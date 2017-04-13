using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthHandler : Health
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;

    [Space(7)][Header("Event")]
    [SerializeField] private UnityEvent _deathEvent;

    public override void AddHealth(float amount)
    {
        base.AddHealth(amount);
        CheckCurrentHealth();
        print(_currentHealth);
    }

    public override void SubtractHealth(float amount)
    {
        base.SubtractHealth(amount);
        CheckCurrentHealth();
        print(_currentHealth);
    }

    private void CheckCurrentHealth()
    {
        if (_currentHealth < _maxHealth || _maxHealth == 0)
        {
            if (_currentHealth < _minHealth)
            {
                _deathEvent.Invoke();
                _currentHealth = _minHealth;
            }
            return;
        }

        _currentHealth = _maxHealth;
    }
}
