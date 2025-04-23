using UnityEngine;

public class BossEnemy : ActiveEnemy
{
    public BossEnemy(float moveSpeed, float jumpSpeed, int health, Rigidbody2D enemyRigidBody) : base(moveSpeed, jumpSpeed, health, enemyRigidBody)
    {
    }
}
