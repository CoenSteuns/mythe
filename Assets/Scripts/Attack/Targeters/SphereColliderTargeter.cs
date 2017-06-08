using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColliderTargeter : AttackTargeter {

    [SerializeField] private float _range;
    [SerializeField] private Vector3 _offset = Vector3.zero;
    [SerializeField] private bool _drawGizmos = false;

    public override Collider[] GetAttackTargets()
    {

        var cols = Physics.OverlapSphere(transform.position + _offset, _range);
        return cols;
    }

    void OnDrawGizmos()
    {
        if (!_drawGizmos) { return; }
        Gizmos.DrawWireSphere(transform.position + _offset, _range);
    }
}
