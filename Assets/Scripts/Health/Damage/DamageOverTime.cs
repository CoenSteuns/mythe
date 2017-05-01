using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    [SerializeField] private float _damagePerSecond;
    [Space(15)] [SerializeField] private string _healthHolder;//Name of the object with the HealthHandler component.

    private HealthHandler _health;//The health handler.

    private bool _isDamaging;

    public float DamagePerSecond
    {
        get { return _damagePerSecond; }
        set { DamagePerSecond = value; }
    }

    public bool IsDamaging
    {
        get { return _isDamaging; }
    }

    void Start()
    {
        _health = GameObject.Find(_healthHolder).GetComponent<HealthHandler>();
    }

    /// <summary>
    /// Start damaging the health.
    /// </summary>
    public void StartDamaging()
    {
        if (_health == null || _isDamaging)
            return;

        _isDamaging = true;
        StartCoroutine(Damage());
    }

    /// <summary>
    /// Stom damaging the health.
    /// </summary>
    public void StopDamaging()
    {
        _isDamaging = false;
    }

    /// <summary>
    /// Damages the healthHandler.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Damage()
    {
        while (_isDamaging)
        {
            _health.SubtractHealth(_damagePerSecond * Time.deltaTime);
            yield return null;
        }
    }

}
