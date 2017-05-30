using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAttack : AttackAction {

    [SerializeField] private float damage;
    [SerializeField] private bool perSecond;

    protected override void OnAttack(Collider col)
    {
        var dam = perSecond ? damage * Time.deltaTime : damage;
        col.gameObject.GetComponent<HealthHandler>().SubtractHealth(dam);
    }



}
