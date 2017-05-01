using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintMovement : Movement
{
    [SerializeField] private float _sprintSpeed = 60;

    private bool _isSprinting = false;//If the object is sprinting.

    public bool IsSprinting
    {
        get { return _isSprinting; }
        set { _isSprinting = value; }
    }

    private Vector3 movementVector;//the direction it is moving towards.

    void FixedUpdate()
    {
        var speed = _isSprinting ? _sprintSpeed : _speed;
        Move(movementVector, speed);
    }

    public void SetMovement(Vector3 movement)
    {
        movementVector = movement;
    }


}
