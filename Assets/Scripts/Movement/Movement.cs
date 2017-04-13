using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{

    [SerializeField] protected float _power = 2;
    protected bool _canMove = true;
    protected Vector3 _movementChange;
    private Rigidbody rigidbody;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }



    public void Move(Vector3 _velocity, float speed = 2)
    {
        if (!_canMove)
        {
            return;
        }

        _velocity = transform.TransformDirection(_velocity);
        _velocity *= speed;

        Vector3 rigidbodyVelocity = rigidbody.velocity;
        Vector3 velocityChange = (_velocity - rigidbodyVelocity);
        velocityChange = new Vector3(
                Mathf.Clamp(velocityChange.x, -_power, _power),0,
                Mathf.Clamp(velocityChange.z, -1, _power)
            );
        rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

    }

}