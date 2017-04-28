using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private float _jumpStrenght = 50;
    [SerializeField] private float _normalJumpStrenght = 50;

    [Header("Charge")]
    [SerializeField] private float _maxJumpStrenght = 200;
    [SerializeField] private float _ChargeDelay = 3;

    private Rigidbody _rb;
    private Counter _timer;

    private bool _grounded;
    private bool _keyDown;

	void Start ()
	{
	    _timer = new Counter();
	    _timer.SetMonobehavior(this);

	    _rb = GetComponent<Rigidbody>();
	}

    private void Update()
    {
        _grounded = IsGrounded();
        _jumpStrenght = _jumpStrenght > _maxJumpStrenght ? _maxJumpStrenght : _jumpStrenght;
        HandelInput();
    }

    private void Jumper()
    {
        _timer.Reset();
        _rb.AddForce(0, _jumpStrenght, 0, ForceMode.VelocityChange);
		_jumpStrenght = _normalJumpStrenght;
    }

    private bool IsGrounded()
    {
      
        var downRay = transform.TransformDirection(Vector3.down);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, downRay, out hit, 8))
        {
            return hit.collider.CompareTag("Ground");
        }
        return false;
    }

    private void HandelInput()
    {
        if (Input.GetAxisRaw("Jump") == 1 && !_keyDown)
        {
            _keyDown = true;
            _timer.Start();
        }

        if (Input.GetAxisRaw("Jump") == 1 && _keyDown)
        {
            if (_timer.CurrentTime >= _ChargeDelay)
            {
                _jumpStrenght++;
            }
        }
        if (Input.GetAxisRaw("Jump") == 0 && _grounded && _keyDown)
        {
            _timer.Stop();
            Jumper();
            _keyDown = false;
        }
    }

}
