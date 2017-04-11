using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody _rb;

    private Vector3 _dash = Vector3.forward;
    [SerializeField] [Range(0, 500)] private float _dashStrenght;

	// Use this for initialization
	void Start ()
	{
	    _rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    _dash = transform.forward;//transform.TransformDirection(Vector3.forward);
	    if (Input.GetKeyDown("e"))
	    {
	        _rb.AddForce(_dash*_dashStrenght,ForceMode.VelocityChange);
	    }
	}
}
