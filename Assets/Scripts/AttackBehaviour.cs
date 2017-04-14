using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackBehaviour : MonoBehaviour
{

    private Animator _ani;

    [SerializeField] private AnimationClip AttackAni;
	// Use this for initialization
	void Start ()
	{
	    _ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
    private void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            _ani.SetBool("Attack",true);
            StartCoroutine(AttackTimer());

        }


    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(AttackAni.length);
        _ani.SetBool("Attack", false);
    }
}
