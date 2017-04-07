using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{

    [SerializeField] private float _sprintSpeedMultyplier= 1.5f;

    private bool _isSprinting;
    private bool _canSprint = true;

    public void Sprint()
    {
        if (_isSprinting || !_canSprint)
        {
            return;
        }
        print("asdas");
        //_maxSpeed *= _sprintSpeedMultyplier;
        _isSprinting = true;
    }

    void Update()
    {
        StopSprinting();
    }

    private void StopSprinting()
    {
        if (!_isSprinting)
        {
            return;
        }
        print("Hori: " + Input.GetAxisRaw("Horizontal") + " Verti" + Input.GetAxis("Vertical"));
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            //_maxSpeed /= _sprintSpeedMultyplier;
            _isSprinting = false;
        }
    }
}
