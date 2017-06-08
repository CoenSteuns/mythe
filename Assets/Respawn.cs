using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    [SerializeField]
    private GameObject[] _spawnpoints;
    
    public void spawn()
    {
        transform.position = _spawnpoints[Random.Range(0, _spawnpoints.Length)].transform.position;
    }

}
