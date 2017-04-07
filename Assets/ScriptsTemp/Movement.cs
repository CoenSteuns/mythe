using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class Movement : MonoBehaviour
{

    [SerializeField] protected float _acceleration = 15.0f;
    [SerializeField] protected float _maxSpeed = 2;
    protected bool _canMove = true;
    private Rigidbody rigidbody;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (!_canMove)
        {
            return;
        }
        Vector3 InputVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        InputVelocity = transform.TransformDirection(InputVelocity);
        InputVelocity *= _acceleration;

        Vector3 velocity = rigidbody.velocity;
        Vector3 velocityChange = (InputVelocity - velocity);
        velocityChange = new Vector3(
                Mathf.Clamp(velocityChange.x, -_maxSpeed, _maxSpeed),
                0,
                velocityChange.z = Mathf.Clamp(velocityChange.z, -_maxSpeed, _maxSpeed)
            );
        rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

    }

    private void CheckForMacVelocity()
    {
        if (rigidbody.velocity.magnitude < _maxSpeed)
        {
            return;
        }

        rigidbody.velocity = rigidbody.velocity.normalized;
        rigidbody.velocity *= _maxSpeed;
        print(rigidbody.velocity.magnitude);
    }

}