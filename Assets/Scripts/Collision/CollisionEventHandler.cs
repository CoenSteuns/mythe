using System.Collections;
using System.Collections.Generic;
using  UnityEngine.Events;
using UnityEngine;

public class CollisionEventHandler : MonoBehaviour {

    [Header("Tags")]
    [SerializeField] private string[] _eventTags;

    [Space(10)][Header("Events")]
    [SerializeField] private UnityEvent _collisionEnterEvent;
    [SerializeField] private UnityEvent _collisionStayEvent;
    [SerializeField] private UnityEvent _collisionExitEvent;

    void OnTriggerEnter(Collider other)
    {
        foreach (var tag in _eventTags)
        {
            if (other.CompareTag(tag))
            {
                _collisionEnterEvent.Invoke();
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        foreach (var tag in _eventTags)
        {
            if (other.CompareTag(tag))
            {
                _collisionStayEvent.Invoke();
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        foreach (var tag in _eventTags)
        {
            if (other.CompareTag(tag))
            {
                _collisionExitEvent.Invoke();
            }
        }
    }

}
