using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Dash : MonoBehaviour
{
    
    [SerializeField] [Range(0, 500)] private float _dashStrenght = 100;//The strength of the dash.
    [SerializeField] private float _cooldownTime = 1;//The time it takes before you can dash agein (in seconds).

    private bool _iSCoolingDown;

    private Rigidbody _rb;
    private GameObject _camera;

    //getters and setters
    public float CooldownTime
    {
        get { return _cooldownTime; }
        set { _cooldownTime = value; }
    }
    public float DashStrenght
    {
        get { return _dashStrenght; }
        set { _dashStrenght = value; }
    }
    public bool IsCoolingDown
    {
        get { return _iSCoolingDown; }
    }

	void Start ()
	{
	    _camera = Camera.main.gameObject;//Gets the main camera.
	    _rb = GetComponent<Rigidbody>();
	}

    /// <summary>
    /// Dashes in the direction the camera is looking.
    /// </summary>
    public void DashToCameraViewDirection()
    {
        DashInDirection(_camera.transform.forward);
    }

    /// <summary>
    /// Dashes forward.
    /// </summary>
    public void DashForward()
    {
        DashInDirection(transform.forward);
    }

    /// <summary>
    /// Dashes the object in a certain direction.
    /// </summary>
    /// <param name="direction">The direction the object will dash in.</param>
    public void DashInDirection(Vector3 direction)
    {
        if (_iSCoolingDown)//Returns if the dash is in cooldown.
            return;

        _rb.AddForce(direction *_dashStrenght, ForceMode.VelocityChange);
        _iSCoolingDown = true;
        StartCoroutine(DashCooldown());
    }

    /// <summary>
    /// Sets the cooldown to false after the cooldown time ends.
    /// </summary>
    /// <returns></returns>
    private IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(_cooldownTime);
        _iSCoolingDown = false;
    }

}
