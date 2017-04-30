using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour {


    public virtual void EnterState() {}
    public virtual void InState() {}
    public virtual void LeaveState() {}

    public abstract void CheckState();


}
