using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour {

    [Header("turningAxis")]
    [SerializeField] private bool _x;
    [SerializeField] private bool _y;

    [Header("Axis")]
    [SerializeField] private string _horizontalAxis;
    [SerializeField] private string _verticalAxis;

    [Header("Speed")]
    [SerializeField] [Range(5,15)] private float _speed;

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        var rotation = transform.eulerAngles + GetInputRotation();
        rotation = CheckRotationBounds(rotation);

        rotation.z = 0;
        transform.eulerAngles = rotation;
    }

    private Vector3 GetInputRotation()
    {
        Vector3 input = new Vector3();
        input.x += _x ? Input.GetAxis(_verticalAxis) * _speed : 0;
        input.y += _y ? Input.GetAxis(_horizontalAxis) * _speed : 0;
        return input;
    }

    
    private Vector3 CheckRotationBounds(Vector3 rotation)
    {
        if (rotation.x > 89.9 && rotation.x < 269.9f)
        {
            rotation.x = rotation.x < 180 ? 89.9f : 269.9f;
        }
        return rotation;
    }

}
