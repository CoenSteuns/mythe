using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public abstract class HitBehavior : MonoBehaviour
{
    [SerializeField] private UnityEvent _onHitEvent;

    [SerializeField] private UnityEvent HitEvent { get { return _onHitEvent; } }

    public void OnHit()
    {
        HitEvent.Invoke();
    }

    public void AddEvent(UnityAction call)
    {
        _onHitEvent.AddListener(call);
    }

}
