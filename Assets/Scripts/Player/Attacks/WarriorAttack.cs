using UnityEngine;

public class WarriorAttack : PlayerAttack
{
    [SerializeField] private GameObject _attackHitbox;

    //Activate hitbox of attack
    public override void Attack()
    {
        _attackHitbox.SetActive(true);
    }

    //Deactivate hitbox of attack
    public override void EndAttack()
    {
        _attackHitbox.SetActive(false);
    }
}
