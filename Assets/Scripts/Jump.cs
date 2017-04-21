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
    private Counter _timer;
	[SerializeField]
	private float _minJumpStr;

    private bool _keyDown;
    private bool TimerON;

    [SerializeField] private float _maxJump;
  //private  Vector3 _v = new Vector3(0,-5,0);



	// Use this for initialization
	void Start ()
	{
	    _timer = new Counter();
	    _timer.SetMonobehavior(this);

	    _rb = GetComponent<Rigidbody>();
	}

    private void Update()
    {


        print(_timer.CurrentTime);
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

            _timer.Start();

            if (_timer.CurrentTime >= 3)
            {
                print(_timer.CurrentTime);
                _jumpStrenght++;

            }
        }
        if (Input.GetAxisRaw("Jump")==0 && _grounded && _keyDown)
        {
            print("gek");
            Jumper();
            _keyDown = false;
        }

    }


    private void Jumper()
    {
        _timer.Reset();
        _rb.AddForce(0, _jumpStrenght, 0, ForceMode.VelocityChange);
		_jumpStrenght = _minJumpStr;
    }






}
