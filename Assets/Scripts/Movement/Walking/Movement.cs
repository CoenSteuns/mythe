using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{

    [SerializeField] protected float _power = 2;
    [SerializeField] protected float _speed = 40;

    protected bool _canMove = true;
    protected Vector3 _movementChange;

    private Rigidbody _rb;

    //Getters and Setters :)
    public float Power
    {
        get { return _power; }
        set { _power = value; }
    }
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    public bool CanMove
    {
        get { return _canMove; }
        set { _canMove = value; }
    }

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Moves the object using the rigidbody.
    /// </summary>
    /// <param name="_velocity">The direction of movement.</param>
    /// <param name="speed">The movement speed.</param>
    public void Move(Vector3 _velocity, float speed = 2)
    {
        if (!_canMove)//Returns if it can't move.
            return;

        //Setting the velocity.
        _velocity = transform.TransformDirection(_velocity);
        _velocity *= speed;

        //Setting the movement.
        Vector3 rigidbodyVelocity = _rb.velocity;
        Vector3 velocityChange = (_velocity - rigidbodyVelocity);
        velocityChange = new Vector3(
                Mathf.Clamp(velocityChange.x, -_power, _power),0,
                Mathf.Clamp(velocityChange.z, -1, _power)
            );

        //moving
        _rb.AddForce(velocityChange, ForceMode.VelocityChange);


    }

}