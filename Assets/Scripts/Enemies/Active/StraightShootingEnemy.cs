using System.Xml.Serialization;
using UnityEngine;

public class StraightShootingEnemy : ShootingEnemy
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MakeAttack();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (Time.time > _shotAttack.GetNextFireTime())
        {
            MakeAttack();
        }
    }
}
