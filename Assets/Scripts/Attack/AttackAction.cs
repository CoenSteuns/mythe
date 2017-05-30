using UnityEngine;

public abstract class AttackAction : MonoBehaviour {

    [SerializeField] private string[] _acceptedColliders;

    [SerializeField] private bool _canAttackMultipleEnemies;

    public void Attack(Collider col)
    {
        AttackCheck(col);

    }

    public void AttackMultiple(Collider[] cols)
    {
        if (!_canAttackMultipleEnemies) { return; }
        for (int i = 0; i < cols.Length; i++)
        {
            AttackCheck(cols[i]);
        }
    }

    private void AttackCheck(Collider col)
    {
        if (col == null)
            return;
        if (_acceptedColliders.Length < 1)
        {
            OnAttack(col);
            return;
        }

        for (int i = 0; i < _acceptedColliders.Length; i++)
        {
            if (col.CompareTag(_acceptedColliders[i]))
            {
                OnAttack(col);
            }
        }
    }

    protected abstract void OnAttack(Collider col);
}
