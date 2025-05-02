using System;
using UnityEngine;

public class RedDinoAimedAttack : Dino
{

    private void Start()
    {
        //NextFireTime = Time.time;
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
