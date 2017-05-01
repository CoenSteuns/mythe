using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollState : PerceptionState {

    [Header("patrolling")]
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _rangeToChangeTarget = 0.1f;

    [Space(10)]
    [Header("Other")]
    [SerializeField] private string _waypontObjectName = "Waypoints";

    private NavMeshAgent _navMeshAgent;
    private GameObject _waypontObject;
    private Transform[] _waypoints;

    private void Start()
    {
        _waypontObject = GameObject.Find(_waypontObjectName);
        _waypoints = _waypontObject.GetComponentsInChildren<Transform>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override void EnterState()
    {
        base.EnterState();
        if (_navMeshAgent == null)
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
        _navMeshAgent.speed = _speed;
    }

    public override void InState()
    {
        if (_navMeshAgent.remainingDistance > _rangeToChangeTarget)
            return;

        setNewTarget();
    }

    public override void CheckState()
    {
        if (GetPerception())
        {
            GetComponent<StateMachine>().SetState(StateID.Follow);
        }
    }

    private void setNewTarget()
    {
        _navMeshAgent.SetDestination(_waypoints[Random.Range(0, _waypoints.Length)].position);
    }
}
