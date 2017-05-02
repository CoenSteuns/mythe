using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float _startHealth = 10;

    protected float _currentHealth;

    //getters and setters
    public float StartHealth
    {
        get { return _startHealth; }
        set { _startHealth = value; }
    }
    public float CurrentHealth
    {
        get { return _currentHealth; }
    }

    void Awake()
    {
        ResetHealth();
    }

    /// <summary>
    /// Subtracts health from the current health
    /// </summary>
    /// <param name="amount">The subtracted amount.</param>
    public virtual void SubtractHealth(float amount)
    {
        _currentHealth -= amount;
        
    }

    /// <summary>
    /// Adds to the current health.
    /// </summary>
    /// <param name="amount">The added amount.</param>
    public virtual void AddHealth(float amount)
    {
        _currentHealth += amount;
    }
    
    /// <summary>
    /// Resets health to start health.
    /// </summary>
    public virtual void ResetHealth()
    {
        _currentHealth = _startHealth;
    }

}
