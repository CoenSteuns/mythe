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

    private bool _KeyUp;

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

        if (Physics.Raycast(transform.position, downRay, out hit, 8))
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

        if (Input.GetAxisRaw("Jump")==1)
        {
            _KeyUp = true;
                _timer++;
            if (_timer > 100)
            {
                _jumpStrenght++;

            }
        }
        if (Input.GetAxisRaw("Jump")==0 && _grounded && _KeyUp)
        {
            print("gek");
            Jumper();
            _timer = 0;
            _KeyUp = false;
        }

    }

    private void Jumper()
    {
        _rb.AddForce(0, _jumpStrenght, 0, ForceMode.VelocityChange);
        _jumpStrenght = 5;
    }





}
