using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    [SerializeField] private float _damagePerSecond;
    [Space(15)]
    [SerializeField] private HealthHandler _health;

    private bool _isDamaging;

    public float DamagePerSecond
    {
        get { return _damagePerSecond; }
        set { DamagePerSecond = value; }
    }

    public void StartDamaging()
    {
        _isDamaging = true;
    }
    public void StopDamaging()
    {
        _isDamaging = false;
    }

    void Update()
    {
        if (!_isDamaging)
        {
            return;
        }
        _health.SubtractHealth(_damagePerSecond*Time.deltaTime);
    }

}
