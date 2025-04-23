using UnityEngine;

public class Enemy
{
    [SerializeField] public float MoveSpeed_ { get; protected set; }
    [SerializeField] public float JumpSpeed_ { get; protected set; }
    [SerializeField] public int Health_ { get; protected set; }

    public bool CanTakeDamage_ { get; set; } = true;

    public readonly Rigidbody2D enemyRigidBody_;

    public Enemy(float moveSpeed, float jumpSpeed, int health, Rigidbody2D enemyRigidBody)
    {
        MoveSpeed_ = moveSpeed;
        JumpSpeed_ = jumpSpeed;
        Health_ = health;
        enemyRigidBody_ = enemyRigidBody;
    }

    public virtual void Attack() { }
    public virtual void Move(bool facingRight, bool facingUp) { }
    public virtual void TakeDamage(int damage) { }
}
