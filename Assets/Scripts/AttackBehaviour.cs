using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AttackBehaviour : MonoBehaviour
{

    private Animator _ani;
    private bool _isAttacking = false;
    [SerializeField] private UnityEvent _death;

    [SerializeField] private AnimationClip AttackAni;

    public bool IsAttacking
    {
        get { return _isAttacking; }
    }

    // Use this for initialization
    void Start()
    {
		_ani = GetComponentInChildren<Animator>();
    }


    public void Attack()
    {
        RaycastHit hit;
        Vector3 fwdRay = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwdRay, Color.black);

        if (Physics.Raycast(transform.position, fwdRay, out hit, 8))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                _death.Invoke();
            }
            _isAttacking = true;
            StartCoroutine(AttackTimer());

        }
    }

        public IEnumerator AttackTimer()
        {
            yield return new WaitForSeconds(AttackAni.length);
            _isAttacking = false;
            _ani.SetBool("Attack", false);
        }
    
}
