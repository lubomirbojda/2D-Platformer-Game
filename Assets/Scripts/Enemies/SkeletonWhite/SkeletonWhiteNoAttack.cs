using UnityEngine;

public class SkeletonWhiteNoAttack : MonoBehaviour
{
    private SkeletonWhite _enemy;
    [SerializeField] private bool _isFacingRight;
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _deathAudioClip;
    [SerializeField] private AudioClip _hitAudioClip;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //var enemyRigidBody = GetComponent<Rigidbody2D>();
        _enemy = new SkeletonWhite(1.5f, 5f, 3, _rigidbody);
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemy.IsDead)
        {
            Destroy(gameObject);
            AudioPlay.PlayAudioClip(_audioSource, _deathAudioClip);
        }
           
        _enemy.Move(_isFacingRight, false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _enemy.CheckEnterCollisionWithPlayerAttack(collision, _audioSource, _hitAudioClip);

        if (collision.CompareTag("EnemyMovePoint"))
        {
            _isFacingRight = !_isFacingRight;
            _enemy.EnemyRigidBody.transform.Rotate(0, 180, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _enemy.CheckExitCollisionWithPlayerAttack(collision);
    }
}
