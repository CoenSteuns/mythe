using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private UnityEvent _death;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands"))
        {
           _death.Invoke();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
