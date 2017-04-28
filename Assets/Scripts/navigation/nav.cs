using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class nav : MonoBehaviour
{
    [SerializeField] private GameObject _waypointObject;
    private NavMeshAgent _n;
    private Transform[] _waypoints;

	// Use this for initialization
	void Start ()
	{
        _waypointObject = GameObject.Find("waypoints");
	    _waypoints = _waypointObject.GetComponentsInChildren<Transform>();
        _n = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (_n.remainingDistance < 0.1)
	    {
	     setNewTarget();   
	    }
	}

    void setNewTarget()
    {
        _n.SetDestination(_waypoints[Random.Range(0, _waypoints.Length)].position);
    }
}
