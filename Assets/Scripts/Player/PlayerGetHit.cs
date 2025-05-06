using System.Collections;
using UnityEngine;

public class PlayerGetHit : MonoBehaviour
{
    [SerializeField] private int _playerHealth;
    private bool _isDead = false;

    private float _invincibilityDuration = 1.5f;
    private SpriteRenderer _spriteRenderer;

    private bool _isInvincible = false;

    private void Start()
    {
        if (AbiilitiesSelection.IsAbilityActiveByIndex(0))
        {
            _playerHealth++;
        }

        var player = GameObject.FindGameObjectWithTag("Player");
        _spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (_isInvincible)
            {
                return;
            } 

            _playerHealth -= 1;
            if (_playerHealth <= 0)
            {
                _isDead = true;
            }
            StartCoroutine(InvincibilityCoroutine());
            Debug.Log("Dostal si hit");
            Debug.Log("Hp: " + _playerHealth);
        }
    }

    private IEnumerator InvincibilityCoroutine()
    {
        _isInvincible = true;

        float elapsed = 0f;
        float blinkInterval = 0.1f;

        while (elapsed < _invincibilityDuration)
        {
            _spriteRenderer.enabled = !_spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
            elapsed += blinkInterval;
        }

        _spriteRenderer.enabled = true;
        _isInvincible = false;
    }

    public bool IsDead()
    {
        return _isDead;
    }
}
