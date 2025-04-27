using UnityEngine;

public class SkeletonWhite : PassiveEnemy
{
    [SerializeField] protected bool IsFacingRight;
    public override void Attack()
    {
        
    }

    public override void Move(bool facingRight, bool facingUp)
    {
        if (facingRight)
        {
            
            EnemyRigidBody.linearVelocity = new Vector2 (MoveSpeed, EnemyRigidBody.linearVelocityY);
        }
        else
        {
            EnemyRigidBody.linearVelocity = new Vector2(MoveSpeed * -1, EnemyRigidBody.linearVelocityY);
        }
    }

}
