using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTarget : MonoBehaviour {

    [SerializeField] private GameObject target;
    [SerializeField] private StateMachine sm;
    [SerializeField] private string _waypointObjectName;


    private GameObject _waypontObject;
    private Transform[] _waypoints;

    private void Start()
    {
        _waypontObject = GameObject.Find(_waypointObjectName);
        _waypoints = _waypontObject.GetComponentsInChildren<Transform>();
        target.GetComponent<EnemyBehaviour>().death.AddListener(Respawn);
        sm = target.GetComponent<StateMachine>();
    }

    private void Respawn()
    {
        target.transform.position = _waypoints[Random.Range(0, _waypoints.Length)].position;
        sm.SetState(StateID.Patroll);
    }
}
