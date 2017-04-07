using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    private float _jumpStrenght;
    private bool _grounded;
    private Rigidbody _rb;
    [SerializeField]
    private float _timer;

    [SerializeField] private float _maxJump = 800;
  //private  Vector3 _v = new Vector3(0,-5,0);



	// Use this for initialization
	void Start ()
	{
	    _rb = GetComponent<Rigidbody>();
	}

    void Update()
    {

        RaycastHit hit;
        Vector3 downRay = transform.TransformDirection(Vector3.down);
        Debug.DrawRay(transform.position, downRay, Color.black);

        if (Physics.Raycast(transform.position, downRay, out hit, 1))
        {
            if (hit.collider.tag == "Ground")
            {
                _grounded = true;
            }
            else
            {
                _grounded = false;
            }
        }
        else
        {
            _grounded = false;
        }
        if (_jumpStrenght > _maxJump)
        {
            _jumpStrenght = _maxJump;
        }

        if (Input.GetKey("space"))
        {
                _timer++;
            if (_timer > 100)
            {
                _jumpStrenght++;

            }
        }
        if (Input.GetKeyUp("space") && _grounded)
        {
            Jumper();
            _timer = 0;
        }

    }

    private void Jumper()
    {
        _rb.AddForce(0, _jumpStrenght, 0);
        _jumpStrenght = 400;
    }





}
