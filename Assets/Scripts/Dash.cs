using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Dash : MonoBehaviour
{
    
    [SerializeField] [Range(0, 500)] private float _dashStrenght = 100;
    [SerializeField] private float _cooldownTime = 1;

    private bool _iSCoolingDown;

    private Rigidbody _rb;
    private GameObject _camera;

	void Start ()
	{
	    _camera = Camera.main.gameObject;
	    _rb = GetComponent<Rigidbody>();
	}

    public void DashToCameraViewDirection()
    {
        DashInDirection(_camera.transform.forward);
    }

    public void DashForward()
    {
        DashInDirection(transform.forward);
    }

    public void DashInDirection(Vector3 direction)
    {
        if (_iSCoolingDown)
            return;

        _rb.AddForce(direction *_dashStrenght, ForceMode.VelocityChange);
        _iSCoolingDown = true;
        StartCoroutine(DashCooldown());
    }

    private IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(_cooldownTime);
        _iSCoolingDown = false;
    }

}
