using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour {

    [Header("turningAxis")]
    [SerializeField] private bool _x;
    [SerializeField] private bool _y;

    [Header("Speed")]
    [SerializeField] [Range(5,15)] private float _speed;

    void Update()
    {
        var Rotation = transform.eulerAngles;
        Rotation.x += _x ? Input.GetAxis("Right Vertical") * _speed : 0;
        Rotation.y += _y ? Input.GetAxis("Right Horizontal") * _speed : 0;
        Rotation.z = 0;
        transform.eulerAngles = Rotation;
    }
	
}
