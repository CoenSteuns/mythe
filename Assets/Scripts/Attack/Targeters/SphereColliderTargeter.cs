using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColliderTargeter : AttackTargeter {

    [SerializeField] private float _range;


    public override Collider[] GetAttackTargets()
    {
        var cols = Physics.OverlapSphere(Vector3.zero, _range);
        return cols;
    }
}
