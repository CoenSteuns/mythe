using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResetWorld : MonoBehaviour {

    public bool resetOnStart;

    public UnityEvent reset;

    public void Start()
    {
        if (!resetOnStart)
            return;

        ResetAll();
    }

    public void ResetAll()
    {
        reset.Invoke();
    }

}
