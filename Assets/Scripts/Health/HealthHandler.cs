using UnityEngine;
using UnityEngine.Events;

public class HealthHandler : Health
{
    [SerializeField] private float _maxHealth;//The maximum amount of health.
    [SerializeField] private float _minHealth;//The minimum amount of health.

    [Header("Event")]
    [SerializeField] private UnityEvent _deathEvent;//Event invoked when the currenhealth drops below the minimum health.

    //Getters and Setters :)
    /// <summary>
    /// Event invoked when the currenhealth drops below the minimum health. (×_×)
    /// </summary>
    public UnityEvent DeathEvent
    {
        get { return _deathEvent; }
        set { _deathEvent = value; }
    }
    public float MaxHealth
    {
        get { return _maxHealth; }
    }
    public float MinHealth
    {
        get { return _minHealth; }
    }

    /// <summary>
    /// Adds to the current health.
    /// </summary>
    /// <param name="amount">The added amount.</param>
    public override void AddHealth(float amount)
    {
        base.AddHealth(amount);
        CheckCurrentHealth();
    }

    /// <summary>
    /// Subtracts health from the current health
    /// </summary>
    /// <param name="amount">The subtracted amount.</param>
    public override void SubtractHealth(float amount)
    {
        base.SubtractHealth(amount);
        CheckCurrentHealth();
    }

    /// <summary>
    /// Check if the health has not gone above the maximum or below the minimum.
    /// </summary>
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
