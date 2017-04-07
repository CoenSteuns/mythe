using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMS : MonoBehaviour
{
    private Rigidbody RB;

    void Start()
    {
        RB = GetComponent<Rigidbody>();

    }

    void Update()
    {
        

        if (Input.GetKey(KeyCode.Space))
        {
            RB.velocity = Vector3.forward * 2;
        }
        else
        {
            RB.velocity = Vector3.zero;
        }
    }
}
