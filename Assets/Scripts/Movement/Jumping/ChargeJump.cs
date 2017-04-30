using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeJump : Jump{

    private Counter _timer;
    private bool _isCharging;

    [Header("Charge")]
    [SerializeField] private float _maxJumpStrenght = 200;
    [SerializeField] private float _ChargeDelay = 3;

    protected override void Start () {
        base.Start();
        _timer = new Counter();
        _timer.SetMonobehavior(this);
    }

    public void StartCharge()
    {
        _timer.Start();
        _isCharging = true;
        StartCoroutine(Charge());
    }

    public void StopCharge()
    {
        _isCharging = false;
        _timer.Stop();
        Jumper();
        ResetJumpStrength();
    }

    private IEnumerator Charge()
    {
        while (_isCharging)
        {
            if(_timer.CurrentTime >= _ChargeDelay)
            {
                _jumpStrenght++;
                _jumpStrenght = _jumpStrenght > _maxJumpStrenght ? _maxJumpStrenght : _jumpStrenght;
            }
            yield return null;
        }
    }
}
