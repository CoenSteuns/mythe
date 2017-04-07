using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    private PlayerMovement p;

	// Use this for initialization
	void Start ()
	{
	    p = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
	    {
	        p.Sprint();

	    }
	}
}
