using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    [SerializeField] private AttackTargeter _targeter;
    [SerializeField] private AttackAction _action;

    public bool isConstanlyAttacking;

    public void AttackTargets()
    {
        _action.Attack(_targeter.GetAttackTarget());
    }
    public void AttackMultipleTargets()
    {
        _action.AttackMultiple(_targeter.GetAttackTargets());
    }

    public void ConstantAttack()
    {
        StartCoroutine(Constant());
    }

    public void ConstantAttackMultiple()
    {
        StartCoroutine(ConstantMult());
    }

    public void StopConstantAttack()
    {
        isConstanlyAttacking = false;
    }

    private IEnumerator Constant()
    {
        while (isConstanlyAttacking)
        {
            AttackTargets();
            yield return null;
        }
    }
    private IEnumerator ConstantMult()
    {
        while (isConstanlyAttacking)
        {
            AttackMultipleTargets();
            yield return null;
        }
    }

}
