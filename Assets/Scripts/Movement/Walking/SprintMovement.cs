using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintMovement : Movement
{
    [SerializeField] private float _sprintSpeed = 60;

    public bool isSprinting = false;

    private Vector3 movementVector;

    void FixedUpdate()
    {
        var speed = isSprinting ? _sprintSpeed : _normalSpeed;
        Move(movementVector, speed);
    }

    public void SetMovement(Vector3 movement)
    {
        movementVector = movement;
    }


}
