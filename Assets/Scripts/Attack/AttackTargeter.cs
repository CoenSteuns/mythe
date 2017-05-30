using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackTargeter : MonoBehaviour {

    public virtual Collider GetAttackTarget()
    {
        return null;
    }

    public virtual Collider[] GetAttackTargets()
    {
        return null;
    }

}
