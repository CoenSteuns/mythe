using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    private float _jumpStrenght = 300;
    private bool _grounded;
    private Rigidbody _rb;
  //private  Vector3 _v = new Vector3(0,-5,0);



	// Use this for initialization
	void Start ()
	{
	    _rb = GetComponent<Rigidbody>();
	}

    void Update()
    {
        print(_grounded);
        RaycastHit hit;
        Vector3 downRay = transform.TransformDirection(Vector3.down);
        Debug.DrawRay(transform.position, downRay, Color.black);
        print("ray: " + Physics.Raycast(transform.position, downRay, out hit, 1));
        if (Physics.Raycast(transform.position, downRay, out hit, 1))
        {
            print("gek");
            if (hit.collider.tag == "Ground")
            {
                _grounded = true;

                print(hit.collider.tag);
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


        if (Input.GetKey("space"))
        {
                 _jumpStrenght += 3;
        }
        if (Input.GetKeyUp("space") && _grounded)
        {
            _jumpStrenght = 400;
            _rb.AddForce(0, _jumpStrenght, 0);
        }
    }






}
