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
            enemyRigidBody_.linearVelocity = new Vector2 (MoveSpeed_, enemyRigidBody_.linearVelocityY);
        }
        else
        {
            enemyRigidBody_.linearVelocity = new Vector2(MoveSpeed_ * -1, enemyRigidBody_.linearVelocityY);
        }
    }

    public override void TakeDamage(int damage)
    {
        if (CanTakeDamage_) 
        {
            Health_ -= damage;
        }
    }
}
