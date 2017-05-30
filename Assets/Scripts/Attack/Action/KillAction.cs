using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAction : AttackAction {

    protected override void OnAttack(Collider col)
    {
        col.gameObject.GetComponent<temp>().Kill();
    }
}
