using UnityEngine;

public class WarriorAttack : PlayerAttack
{
    [SerializeField] private GameObject _attackHitbox;

    public override void Attack()
    {
        _attackHitbox.SetActive(true);
    }

    public override void EndAttack()
    {
        _attackHitbox.SetActive(false);
    }
}
