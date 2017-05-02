using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private ChargeJump _jump;
    private SprintMovement _movement;
	private Animator _ani;
    private bool _jumpKeyDown;
    private bool _jumpWasCharged;
	[SerializeField]
	private AnimationClip _startrunning;
	[SerializeField]
	private AnimationClip _jumpStart;
    private Dash _dash;
    private bool _dashKeyDown;
    private AttackBehaviour _attack;

    // Use this for initialization
    void Start () {
        _movement = GetComponent<SprintMovement>();
        _jump = GetComponent<ChargeJump>();
		_ani = GetComponentInChildren<Animator>();
        _dash = GetComponent<Dash>();
        _attack = GetComponentInChildren<AttackBehaviour>();
        _jump.landEvent.AddListener(Land);
    }
	
	// Update is called once per frame
	void Update () {
        MovementInput();
        JumpInput();
        DashInput();
	    AttackInput();
	}

    private void AttackInput()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetAxisRaw("Attack") == 1 && _attack.IsAttacking == false)
        {
            //attack
            _attack.Attack();

        }
    }

    private void DashInput()
    {
        if (Input.GetKeyDown("e") || Input.GetAxisRaw("Dash") == 1 && _dashKeyDown)
        {
            //dash
            _dash.DashToCameraViewDirection();
        }
        _dashKeyDown = Input.GetAxisRaw("Dash") == 1 ? false : true;
    }

    private void MovementInput()
    {
        var movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (movementInput.magnitude > 0.2)
        {
            if (_movement.IsSprinting || Input.GetAxisRaw("Sprint") == 1)
            {
                //sprinting
                _movement.IsSprinting = true;
                print("sprinting");
            }
            else
            {
                //walking
                _movement.IsSprinting = false;
                print("walking");
            }
        }
        _movement.SetMovement(movementInput);
        /*var movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (movementInput.magnitude > 0.2 && _movement.IsSprinting || movementInput.magnitude > 0.2 && Input.GetAxisRaw("Sprint") == 1)
        { 
			
			
			_movement.IsSprinting = true;
			_ani.SetBool ("StartRun", true);
			StartCoroutine (Running ());
		}
        else
        {
			_movement.IsSprinting = false; 
			_ani.SetBool ("EndRunning", true);
			_ani.SetBool ("Running", false);
		}


        _movement.SetMovement(movementInput);*/
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
            if (_jump.JumpStrength > _jump.NormalJumpStrenght)
            {
                //Jump is charged
                _jumpWasCharged = true;
            }
            else
            {
                //jump is not charged
                _jumpWasCharged = false;
            }
            //_ani.SetBool ("Jump", false);
            _jumpKeyDown = false;
            _jump.StopCharge();
        }
        if (_jump.IsCharging)
        {
            //jump is charging
            print("Charging");
        }
    }


	IEnumerator Running(){
		yield return new WaitForSeconds (_startrunning.length);
		_ani.SetBool ("StartRun", false);
		_ani.SetBool ("Running", true);	
	}

    void Land()
    {
        if (_jumpWasCharged)
        {
            //Jump was charged
        }
        else
        {
            //jump was not charged
        }
    }

}

