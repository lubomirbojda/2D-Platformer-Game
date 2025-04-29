using System;
using UnityEngine;

public class RedDinoAimedAttack : Dino
{

    private void Start()
    {
        NextFireTime = Time.time;
    }

    protected override void Update()
    {
        base.Update();

        if (EnemyActiveZone.IsActive())
        {
            if (Time.time > NextFireTime)
            {
                MakeAttack();
            }
        }
    }

    private void MakeAttack()
    {
        StartAttackAnimation();
        Attack();
        NextFireTime = Time.time + FireDelay;
    }
}
