using UnityEngine;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float MoveSpeed;
    [SerializeField] protected float JumpSpeed;
    [SerializeField] protected int Health;
    [SerializeField] protected Rigidbody2D EnemyRigidBody;

    [SerializeField] protected AudioSource AudioSource;
    [SerializeField] protected AudioClip DeathAudioClip;
    [SerializeField] protected AudioClip HitAudioClip;

    protected bool CanTakeDamage { get; set; } = true;
    protected bool IsDead { get; set; } = false;

    //protected readonly Rigidbody2D EnemyRigidBody;

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

    protected virtual void Update()
    {
        if (IsDead)
        {
            Destroy(gameObject);
            AudioPlay.PlayAudioClip(AudioSource, DeathAudioClip);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            TakeDamage();
            CanTakeDamage = false;
            AudioPlay.PlayAudioClip(AudioSource, HitAudioClip);
            Debug.Log("Enemy zivoty: " + Health);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            CanTakeDamage = true;
        }
    }

    
}
