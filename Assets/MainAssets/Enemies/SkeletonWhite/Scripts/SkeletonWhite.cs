using UnityEngine;

public class SkeletonWhite : Enemy, IEnemy
{
    
    public SkeletonWhite(float moveSpeed, float jumpSpeed, int health, Rigidbody2D enemyRigidBody) : base(moveSpeed, jumpSpeed, health, enemyRigidBody)
    {
    }

    public void Attack()
    {
        
    }

    public void Move(bool facingRight, bool facingUp)
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

    public void TakeDamage(int damage)
    {
        if (CanTakeDamage_) 
        {
            Health_ -= damage;
        }
    }
}
