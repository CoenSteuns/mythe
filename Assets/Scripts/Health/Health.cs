using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float _startHealth = 10;

    protected float _currentHealth;

    void Awake()
    {
        _currentHealth = _startHealth;
    }

    public virtual void SubtractHealth(float amount)
    {
        _currentHealth -= amount;
        
    }

    public virtual void AddHealth(float amount)
    {
        _currentHealth += amount;
    }
    

}
