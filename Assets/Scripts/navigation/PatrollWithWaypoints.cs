using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollWithWaypoints : MonoBehaviour
{
    [Header("patrolling")]
    [SerializeField] private float _speed = 3.5f;//The speed it will patroll at.
    [SerializeField] private float _rangeToChangeTarget = 0.1f;//Range to target before it changes it's target again

    [Space(10)]
    [Header("Waypoints")]
    [SerializeField] private string _waypontObjectName = "Waypoints";//Name of the object which has waypoints as it's childs.

    private bool _isPatroling = true;
    private NavMeshAgent _navMeshAgent;
    private GameObject _waypontObject;
    private Transform[] _waypoints;

    // Use this for initialization
    void Start ()
	{
        _waypontObject = GameObject.Find(_waypontObjectName);
        _waypoints = _waypontObject.GetComponentsInChildren<Transform>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _speed;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void StartPatrolling()
    {
        _isPatroling = true;
        StartCoroutine(Patrol());
    }

    public void StopPatrolling()
    {
        _isPatroling = false;
    }

    private void SetNewTarget()
    {
        _navMeshAgent.SetDestination(_waypoints[Random.Range(0, _waypoints.Length)].position);
    }

    private IEnumerator Patrol()
    {
        while (_isPatroling)
        {
            if (!(_navMeshAgent.remainingDistance > _rangeToChangeTarget))
                SetNewTarget();

            
            yield return null;
        }
    }
}
