using System.Collections;
using UnityEngine;

public class ChargeJump : Jump{

    [Header("Charge")]
    [SerializeField] private float _maxJumpStrenght = 200;
    [SerializeField] private float _chargeSpeed = 1;
    [SerializeField] private float _ChargeDelay = 3;

    private Counter _timer;
    private bool _isCharging;

    //getters and setters
    public float MaxJumpStrenght
    {
        get { return _maxJumpStrenght; }
        set { _maxJumpStrenght = value; }
    }
    public float ChargeSpeed
    {
        get { return _chargeSpeed; }
        set { _chargeSpeed = value; }
    }
    public float ChargeDelay
    {
        get { return _ChargeDelay; }
        set { _ChargeDelay = value; }
    }
    public bool IsCharging
    {
        get { return _isCharging; }
    }
    public Counter Timer
    {
        get { return _timer; }
    }

    protected override void Start () {
        base.Start();
        _timer = new Counter(refreshTime: 0.1f);
        _timer.SetMonobehavior(this);
    }

    /// <summary>
    /// Starts charging the jump.
    /// </summary>
    public void StartCharge()
    {
        _timer.Start();//starts the counter.
        _isCharging = true;
        StartCoroutine(Charge());
    }

    /// <summary>
    /// Stops charging and jumps.
    /// </summary>
    public void StopCharge()
    {
        _isCharging = false;
        _timer.Stop();
        Jumper();
        ResetJumpStrength();
    }

    /// <summary>
    /// Charges the jumpstrength.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Charge()
    {
        while (_isCharging)//If it is charging.
        {
            if(_timer.CurrentTime >= _ChargeDelay)//if the counter is more thatn the chargedelay.
            {
                _jumpStrenght += _chargeSpeed;//adds to the jumpstrength
                _jumpStrenght = _jumpStrenght > _maxJumpStrenght ? _maxJumpStrenght : _jumpStrenght;//checks if the jumpstrength is more than the max jump strength.
            }
            yield return null;
        }
    }
}
