using UnityEngine;

public class GreenDitoShot : EnemyShot
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();

        if (IsFacingRight)
        {
            ShotRigidBody.linearVelocityX = ShotSpeed;
        }
        else
        {
            ShotRigidBody.linearVelocityX = ShotSpeed * -1;
        }

        Destroy(gameObject, ShotLifeTime);
    }

}
