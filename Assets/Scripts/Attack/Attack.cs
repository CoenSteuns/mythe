using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("name")]
    [SerializeField] private string _attackName;

    [Header("Attack")]
    [SerializeField] private AttackTargeter _targeter;
    [SerializeField] private AttackAction _action;

    private bool isConstanlyAttacking;

    public AttackTargeter Targeter { get { return _targeter; } }
    public AttackAction Action { get { return _action; } }

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
        isConstanlyAttacking = true;
        StartCoroutine(Constant());
    }

    public void ConstantAttackMultiple()
    {
        isConstanlyAttacking = true;
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