using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] protected float _jumpStrenght = 50;
    [SerializeField] private float _normalJumpStrenght = 50;

    private Rigidbody _rb;

    public bool Grounded
    {
        get { return IsGrounded(); }
    }

    protected virtual void Start ()
	{
	    _rb = GetComponent<Rigidbody>();
	}

    protected void Jumper()
    {
        if (!IsGrounded()) { return; }
        _rb.AddForce(0, _jumpStrenght, 0, ForceMode.VelocityChange);
        ResetJumpStrength();
    }

    protected void ResetJumpStrength()
    {
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
    

}
