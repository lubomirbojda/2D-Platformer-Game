using System.Xml.Serialization;
using UnityEngine;

public class GreenDinoStraightAttack : Dino
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_animator.SetBool("isAttacking", true);
        MakeAttack();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (Time.time > NextFireTime)
        {
            //_animator.SetBool("isAttacking", true);
            MakeAttack();
        }
    }

    private void MakeAttack()
    {
        StartAttackAnimation();
        Attack();
        NextFireTime = Time.time + FireDelay;
    }
}
