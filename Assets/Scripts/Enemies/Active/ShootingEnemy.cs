using UnityEngine;

public class ShootingEnemy : ActiveEnemy
{
    [SerializeField] protected ShotAttack _shotAttack;

    //Full attack of shooting enemy - animation start, send shot, set next shot delay
    protected void MakeAttack()
    {
        StartAttackAnimation();
        _shotAttack.Attack();
        _shotAttack.SetNextFireTime();
    }

}
