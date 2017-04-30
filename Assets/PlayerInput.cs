﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private ChargeJump _jump;
    private SprintMovement _movement;

    private bool _jumpKeyDown;
    
	// Use this for initialization
	void Start () {
        _movement = GetComponent<SprintMovement>();
        _jump = GetComponent<ChargeJump>();
	}
	
	// Update is called once per frame
	void Update () {
        MovementInput();
        JumpInput();
	}

    private void MovementInput()
    {
        var movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (movementInput.magnitude > 0.2 && _movement.isSprinting || movementInput.magnitude > 0.2 && Input.GetAxisRaw("Sprint") == 1)
        { _movement.isSprinting = true; }
        else
        {_movement.isSprinting = false; }

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
