using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private float _normalJumpStrenght = 50;

    protected float _jumpStrenght = 50;
    private Rigidbody _rb;

    /// <summary>
    /// If the Gameobject is on the ground.
    /// </summary>
    public bool Grounded
    {
        get { return IsGrounded(); }
    }
    public float JumpStrength
    {
        get { return _jumpStrenght; }
    }
    public float NormalJumpStrenght
    {
        get { return _normalJumpStrenght; }
        set { _normalJumpStrenght = value; }
    }
    
    protected virtual void Start ()
	{
        _jumpStrenght = _normalJumpStrenght;
	    _rb = GetComponent<Rigidbody>();
	}

    /// <summary>
    /// Lets the object jump.
    /// </summary>
    protected void Jumper()
    {
        if (!IsGrounded()) { return; }//If the object is not on the ground it wont jump.
        _rb.AddForce(0, _jumpStrenght, 0, ForceMode.VelocityChange);
        ResetJumpStrength();
    }

    /// <summary>
    /// Resets jumpstrenght to normal jump strenght.
    /// </summary>
    protected void ResetJumpStrength()
    {
        _jumpStrenght = _normalJumpStrenght;
    }

    /// <summary>
    /// Checks if the object is on the ground.
    /// </summary>
    /// <returns>If the object is on the ground.</returns>
    private bool IsGrounded()
    {
        var downRay = transform.TransformDirection(Vector3.down);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, downRay, out hit, 8))
        {
            return hit.collider.CompareTag("Ground");
        }
        return false;
    }
    

}
