using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class DeactivateOnVRDevice : MonoBehaviour
{

    [SerializeField] private MonoBehaviour[] _monoBehaviours;

    void Awake()
    {
        if (VRDevice.isPresent)
        {
            foreach (var monobehavior in _monoBehaviours)
            {
                monobehavior.enabled = false;
            }
        }
    }

}
