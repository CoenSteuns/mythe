using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private UnityEvent _death;

    public UnityEvent death { get { return _death; } set { _death = value; } }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update()
    {

    }

    public void Death()
    {
        print("asdas");
        death.Invoke();
    }
}
