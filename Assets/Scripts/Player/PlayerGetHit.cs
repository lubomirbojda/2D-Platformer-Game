using System.Collections;
using UnityEngine;

public class PlayerGetHit : MonoBehaviour
{
    [SerializeField] private int _playerHealt;
    private bool _isDead = false;
    private int _maxHealt;

    private float _invincibilityDuration = 1.5f;
    private SpriteRenderer _spriteRenderer;

    private bool _isInvincible = false;

    //Awake is called before script is initialized
    private void Awake()
    {
        if (AbiilitiesSelection.IsAbilityActiveByIndex(0))
        {
            _playerHealt++;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        _spriteRenderer = player.GetComponent<SpriteRenderer>();
        _maxHealt = _playerHealt;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (_isInvincible)
            {
                return;
            } 

            _playerHealt -= 1;
            if (_playerHealt <= 0)
            {
                _isDead = true;
            }
            StartCoroutine(InvincibilityCoroutine());
            Debug.Log("Dostal si hit");
            Debug.Log("Hp: " + _playerHealt);
        }
    }

    //IEnumerator which makes blink effect of player when he gets hit from enemy
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

    public int GetActualHealth()
    {
        return _playerHealt;
    }

    public int GetMaxhealt()
    {
        return _maxHealt;
    }
}
