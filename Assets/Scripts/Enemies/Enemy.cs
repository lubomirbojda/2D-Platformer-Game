using UnityEngine;

public class Enemy
{
    public float MoveSpeed { get; protected set; }
    public float JumpSpeed { get; protected set; }
    public int Health { get; protected set; }

    public bool CanTakeDamage { get; set; } = true;

    public readonly Rigidbody2D EnemyRigidBody;

    public bool IsDead { get; protected set; } = false;


    public Enemy(float moveSpeed, float jumpSpeed, int health, Rigidbody2D enemyRigidBody)
    {
        MoveSpeed = moveSpeed;
        JumpSpeed = jumpSpeed;
        Health = health;
        EnemyRigidBody = enemyRigidBody;
    }

    public virtual void Attack() { }
    public virtual void Move(bool facingRight, bool facingUp) { }
    public virtual void TakeDamage() 
    {
        if (CanTakeDamage)
        {
            Health--;
        }

        if (Health <= 0)
        {
            IsDead = true;
        }
    }

    public void CheckEnterCollisionWithPlayerAttack(Collider2D collision, AudioSource audioSource, AudioClip hitAudioClip)
    {
        if (collision.CompareTag("Attack"))
        {
            TakeDamage();
            CanTakeDamage = false;
            AudioPlay.PlayAudioClip(audioSource, hitAudioClip);
            Debug.Log("Enemy zivoty: " + Health);
        }
    }

    public void CheckExitCollisionWithPlayerAttack(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            CanTakeDamage = true;
        }
    }
}
