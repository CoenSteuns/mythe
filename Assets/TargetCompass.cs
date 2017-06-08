using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCompass : MonoBehaviour {

    [SerializeField]
    private GameObject _target;

    [SerializeField]
    private GameObject follower;

    [SerializeField]
    private float offset;

	void Update () {
        transform.position = follower.transform.position + ((_target.transform.position - follower.transform.position).normalized * offset);
	}
}
