using System.Collections;
using System.Collections.Generic;
using  UnityEngine.Events;
using UnityEngine;

public class TriggerEventHandler : MonoBehaviour {

    [Header("Tags")]
    [SerializeField] private List<string> _eventTags;//accepted tags

    [Space(10)][Header("Events")]
    [SerializeField] private UnityEvent _collisionEnterEvent;//Invoked OnTriggerEnter is called and the other tag is an accepted tag.
    [SerializeField] private UnityEvent _collisionStayEvent;//Invoked OnTriggerStay is called and the other tag is an accepted tag.
    [SerializeField] private UnityEvent _collisionExitEvent;//Invoked OnTriggerExit is called and the other tag is an accepted tag.

    //Getters and Setters
    public UnityEvent CollisionEnterEvent
    {
        get { return _collisionEnterEvent; }
        set { _collisionEnterEvent = value; }
    }
    public UnityEvent CollisionStayEvent
    {
        get { return _collisionStayEvent; }
        set { _collisionStayEvent = value; }
    }
    public UnityEvent CollisionExitEvent
    {
        get { return _collisionExitEvent; }
        set { _collisionExitEvent = value; }
    }

    public List<string> EventTags
    {
        get { return _eventTags; }
    }

    void OnTriggerEnter(Collider other)
    {
        if (OtherTagIsAccepted(other))
            _collisionEnterEvent.Invoke();
    }
    void OnTriggerStay(Collider other)
    {
        if (OtherTagIsAccepted(other))
            _collisionStayEvent.Invoke();          
    }
    void OnTriggerExit(Collider other)
    {
        if(OtherTagIsAccepted(other))
            _collisionExitEvent.Invoke();
    }

    private bool OtherTagIsAccepted(Collider other)
    {
            if (_eventTags.IndexOf(other.tag) == -1)
            {
                return false;
            }
        return true;
    }

}
