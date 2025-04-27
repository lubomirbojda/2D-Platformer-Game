using UnityEngine;

public class SkeletonWhite : PassiveEnemy
{
    
    public SkeletonWhite(float moveSpeed, float jumpSpeed, int health, Rigidbody2D enemyRigidBody) : base(moveSpeed, jumpSpeed, health, enemyRigidBody)
    {
    }

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
