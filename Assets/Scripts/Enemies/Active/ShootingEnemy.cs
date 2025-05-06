using UnityEngine;

public class ShootingEnemy : ActiveEnemy
{
    [SerializeField] protected ShotAttack _shotAttack;

    protected void MakeAttack()
    {
        StartAttackAnimation();
        _shotAttack.Attack();
        _shotAttack.SetNextFireTime();
    }

}
