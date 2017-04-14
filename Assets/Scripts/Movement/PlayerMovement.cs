using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{

    [SerializeField] private float _normalSpeed = 15;
    [SerializeField] private float _sprintSpeed = 25;

    private bool _isSprinting = false;

    void FixedUpdate()
    {
        
        var inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        var speed = IsSprinting(inputVector) ? _sprintSpeed : _normalSpeed;
        Move(inputVector, speed);
    }

    private bool IsSprinting(Vector3 input)
    {
        if (input.magnitude > 0.2 && _isSprinting || input.magnitude > 0.2 && Input.GetAxisRaw("Sprint") == 1)
        {
            _isSprinting = true;
            return true;
        }
        _isSprinting = false;
        return false;
    }


}
