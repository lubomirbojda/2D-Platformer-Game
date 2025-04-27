using UnityEngine;

public class PassiveEnemy : Enemy
{
    public PassiveEnemy(float moveSpeed, float jumpSpeed, int health, Rigidbody2D enemyRigidBody) : base(moveSpeed, jumpSpeed, health, enemyRigidBody)
    {
    }


}
