using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputTemp : MonoBehaviour {

    private ChargeJump _jump;
    private SprintMovement _movement;
    private Dash _dash;

    private bool _jumpKeyDown;
    private bool _dashKeyDown;
    
	// Use this for initialization
	void Start () {
        _movement = GetComponent<SprintMovement>();
        _jump = GetComponent<ChargeJump>();
	    _dash = GetComponent<Dash>();
	}
	
	// Update is called once per frame
	void Update () {
        MovementInput();
        JumpInput();
	    DashInput();
	}

    private void DashInput()
    {
        if (Input.GetKeyDown("e") || Input.GetAxisRaw("Dash") == 1 && _dashKeyDown)
        {
           _dash.DashToCameraViewDirection();
        }
        _dashKeyDown = Input.GetAxisRaw("Dash") == 1 ? false : true;
    }

    private void MovementInput()
    {
        var movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (movementInput.magnitude > 0.2 )
        {
            if (_movement.IsSprinting || Input.GetAxisRaw("Sprint") == 1)
            {
                _movement.IsSprinting = true;
            }
            else
            {
                _movement.IsSprinting = false;
            }
        }
        _movement.SetMovement(movementInput);
    }

    private void JumpInput()
    {
        if (Input.GetAxisRaw("Jump") == 1 && !_jumpKeyDown)
        {
            _jumpKeyDown = true;
            _jump.StartCharge();
        }
        if (Input.GetAxisRaw("Jump") == 0 && _jumpKeyDown)
        {
            _jumpKeyDown = false;
            _jump.StopCharge();
        }
    }
}
