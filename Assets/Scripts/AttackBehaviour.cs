using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackBehaviour : MonoBehaviour
{

    private Animator _ani;
	// Use this for initialization
	void Start ()
	{
	    _ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
    private void Update () {
	    if (Input.GetMouseButtonDown(0))
	    {

            _ani.SetFloat("Attack",1f);
	        //_ani.SetFloat("Attack", 0.1f);

	    }
	    if (Input.GetMouseButtonUp(0))

	    {
	        _ani.SetFloat("Attack", 0.1f);
	    }

		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
           Destroy(other.gameObject);
        }
    }
}
