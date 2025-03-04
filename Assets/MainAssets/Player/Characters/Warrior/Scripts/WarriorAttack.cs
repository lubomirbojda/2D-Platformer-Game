using UnityEngine;

public class WarriorAttack : PlayerAttack
{
    [SerializeField] private GameObject attackHitbox_;

    public override void Attack()
    {
        attackHitbox_.SetActive(true);
    }

    public override void EndAttack()
    {
        attackHitbox_.SetActive(false);
    }
}
