using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTargeter : AttackTargeter {

    [SerializeField] private float _range;

    public override Collider GetAttackTarget()
    {
        RaycastHit hit;
        Vector3 fwdRay = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwdRay, out hit, _range))
        {
            return hit.collider;

        }
        return null;
    }

}
