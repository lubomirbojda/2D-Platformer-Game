using UnityEngine;

public class ActiveEnemy : Enemy
{
    public ActiveEnemy(float moveSpeed, float jumpSpeed, int health, Rigidbody2D enemyRigidBody) : base(moveSpeed, jumpSpeed, health, enemyRigidBody)
    {
    }
}
