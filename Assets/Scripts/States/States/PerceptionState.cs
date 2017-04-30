using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PerceptionState : State {
    
    [Header("perception")]
    [SerializeField] protected float _rangeOfPerception = 1;
    [SerializeField] protected float _distanceToFront = 2;

    [Header("collider")]
    [SerializeField] private string[] _acceptedColliders;
    [SerializeField] private bool _ifContains = true;
    [Space(10)]
    [SerializeField] private bool _drawGizmos = false;
    [SerializeField] private bool _drawGizmosOnEnterState = false;

    public override void EnterState()
    {
        if (_drawGizmosOnEnterState)
        {
            _drawGizmos = true;
        }
    }

    public override void LeaveState()
    {
        if (_drawGizmosOnEnterState)
        {
            _drawGizmos = false;
        }
    }

    protected bool GetPerception()
    {
        var colliders = Physics.OverlapSphere(transform.position + transform.forward * _distanceToFront, _rangeOfPerception);
        for (int i = 0; i < colliders.Length; i++)
        {
            foreach (var tag in _acceptedColliders)
            {
                if (colliders[i].CompareTag(tag))
                {
                    return _ifContains;
                }
            }
        }
        return !_ifContains;
    }

    void OnDrawGizmos()
    {
        if (!_drawGizmos) { return; }
        Gizmos.DrawWireSphere(transform.position + transform.forward * _distanceToFront, _rangeOfPerception);
    }
}
