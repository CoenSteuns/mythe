using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class Movement : MonoBehaviour
{

    [SerializeField][Range(10, 20)] protected float _acceleration = 15.0f;
    [SerializeField][Range(1,15)] protected float _maxSpeed = 2;
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
        CheckForMacVelocity();
        rigidbody.AddForce(InputVelocity * _acceleration / Time.fixedDeltaTime, ForceMode.Force);
    }

    private void CheckForMacVelocity()
    {
        if (rigidbody.velocity.magnitude < _maxSpeed)
        {
            return;
        }

        rigidbody.velocity = rigidbody.velocity.normalized;
        rigidbody.velocity *= _maxSpeed;
    }

}