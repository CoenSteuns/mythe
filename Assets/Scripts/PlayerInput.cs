using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private ChargeJump _jump;
    private SprintMovement _movement;
	private Animator _ani;
    private bool _jumpKeyDown;
	[SerializeField]
	private AnimationClip _startrunning;
	private AnimationClip _Endrunning;
    
	// Use this for initialization
	void Start () {
        _movement = GetComponent<SprintMovement>();
        _jump = GetComponent<ChargeJump>();
		_ani = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        MovementInput();
        JumpInput();
	}

	private void MovementInput()
    {
        var movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (movementInput.magnitude > 0.2 && _movement.isSprinting || movementInput.magnitude > 0.2 && Input.GetAxisRaw("Sprint") == 1)
        { 
			
			_movement.isSprinting = true;
			_ani.SetBool ("StartRun", true);
			StartCoroutine (Running ());
		}
        else
        {
			_movement.isSprinting = false; 
			_ani.SetBool ("EndRunning", true);
			_ani.SetBool ("Running", false);
		}

        _movement.SetMovement(movementInput);
    }

    private void JumpInput()
    {
        if (Input.GetAxisRaw("Jump") == 1 && !_jumpKeyDown)
        {
            _jumpKeyDown = true;
            _jump.StartCharge();
        }
        if (Input.GetAxisRaw("Jump") == 0 && _jumpKeyDown)
        {
            _jumpKeyDown = false;
            _jump.StopCharge();
        }
    }
	IEnumerator Running(){
		yield return new WaitForSeconds (_startrunning.length);
		_ani.SetBool ("StartRun", false);
		_ani.SetBool ("Running", true);	
	}

}

