using UnityEngine;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int Health;
    [SerializeField] protected AudioSource AudioSource;
    [SerializeField] protected AudioClip DeathAudioClip;
    [SerializeField] protected AudioClip HitAudioClip;

    protected bool CanTakeDamage { get; set; } = true;
    protected bool IsDead { get; set; } = false;

    private int _maxHealth;

    private void Start()
    {
        _maxHealth = Health;
    }

    protected virtual void TakeDamage() 
    {
        int damage = 1;
        if (PlayerPrefs.HasKey("PlayerDamage"))
        {
            damage = PlayerPrefs.GetInt("PlayerDamage");
        }
        if (CanTakeDamage)
        {
            Health -= damage;
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

    public int GetHealth()
    {
        return Health;
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }
}
