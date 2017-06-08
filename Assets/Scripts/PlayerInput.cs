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
    Attack _attack;

    // Use this for initialization
    void Start () {
        _movement = GetComponent<SprintMovement>();
        _jump = GetComponent<ChargeJump>();
		_ani = GetComponentInChildren<Animator>();
        _dash = GetComponent<Dash>();
        _attack = GetComponentInChildren<Attack>();
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
        if (Input.GetMouseButtonDown(0) || Input.GetAxisRaw("Attack") == 1)
        {
            //attack
            _attack.AttackTargets();
			_ani.SetBool("Attack", true);

        }
    }

    private void DashInput()
    {
        if (Input.GetKeyDown("e") || Input.GetAxisRaw("Dash") == 1 && _dashKeyDown)
        {
            //dash
			_ani.SetBool("Dash",true);
            _dash.DashToCameraViewDirection();
        }
        _dashKeyDown = Input.GetAxisRaw("Dash") == 1 ? false : true;

    }

    private void MovementInput()
    {
		_ani.SetBool ("Walking", false);
		_ani.SetBool ("Running", false);
		_ani.SetBool ("Dash", false);

		_movement.IsSprinting = false;
        var movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (movementInput.magnitude > 0.2)
        {
            if (_movement.IsSprinting || Input.GetAxisRaw("Sprint") == 1)
            {
                //sprinting
				_ani.SetBool("StartRun",true);
                _movement.IsSprinting = true;
				StartCoroutine(Running());

            }
            else
            {
                //walking
				_ani.SetBool("EndRunning",true);
				_ani.SetBool("Walking",true);
                _movement.IsSprinting = false;

            }
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
            if (_jump.JumpStrength > _jump.NormalJumpStrenght)
            {
                //Jump is charged
				_ani.SetBool("ChargeJump",true);
				_ani.SetBool("Charging",false);
                _jumpWasCharged = true;
            }
            else
            {
                //jump is not charged
				_ani.SetBool("Jump",true);
				_ani.SetBool("ChargeJump",false);
                _jumpWasCharged = false;
            }
            //_ani.SetBool ("Jump", false);
            _jumpKeyDown = false;
            _jump.StopCharge();
        }
        if (_jump.IsCharging)
        {
			_ani.SetBool("Charging",true);
			_ani.SetBool("Running",false);


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
			_ani.SetBool("ChargeJumpLand",true);
			_ani.SetBool("ChargeJump",false);
			_ani.SetBool("Charging",false);
        }
        else
        {
            //jump was not charged
			_ani.SetBool("JumpLand",false);
			_ani.SetBool("Jump",false);
        }
    }

}

