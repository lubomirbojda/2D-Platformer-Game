using System;
using UnityEngine;

public class AimedShootingEnemy : ShootingEnemy
{

    private void Start()
    {
        _shotAttack.SetNewFireTime(Time.time);
    }

    protected override void Update()
    {
        base.Update();

        if (EnemyActiveZone.IsActive())
        {
            if (Time.time > _shotAttack.GetNextFireTime())
            {
                MakeAttack();
            }
        }
    }

    
}
