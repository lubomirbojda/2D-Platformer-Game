using System;
using UnityEngine;

public class AimedShootingEnemy : ShootingEnemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _shotAttack.SetNewFireTime(Time.time);
    }

    // Update is called once per frame
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
