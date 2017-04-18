using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private float GravityStr;
    private Rigidbody _rb;
	// Use this for initialization
	void Start ()
	{
	    _rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		_rb.AddForce(0,GravityStr,0);
	}
}
