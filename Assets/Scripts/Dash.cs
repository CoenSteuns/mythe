using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody _rb;

    private GameObject _camera;
    private Vector3 _dash = Vector3.forward;
    [SerializeField] [Range(0, 500)] private float _dashStrenght;

	private bool _keyUp = true;

	// Use this for initialization
	void Start ()
	{
	    _camera = Camera.main.gameObject;
	    _rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    _dash = _camera.transform.forward;//transform.TransformDirection(Vector3.forward);

		if (Input.GetKeyDown("e") || Input.GetAxisRaw("Dash") == 1 && _keyUp)
	    {
	        _rb.AddForce(_dash*_dashStrenght,ForceMode.VelocityChange);
	    }
		_keyUp = Input.GetAxisRaw ("Dash") == 1 ? false : true;
	}
}
