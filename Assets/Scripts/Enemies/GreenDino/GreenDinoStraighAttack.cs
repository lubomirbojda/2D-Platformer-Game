using UnityEngine;

public class GreenDinoStraighAttack : MonoBehaviour
{
    private GreenDino _enemy;
    [SerializeField] private float _fireDelay;
    private float _nextFireTime;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GameObject _shot;
    [SerializeField] private GameObject _startingPosition;
    [SerializeField] private Animator _animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enemy = new GreenDino(0, 0, 3, _rigidbody, _shot, _startingPosition);
        _animator.SetBool("isAttacking", true);
        _enemy.Attack();
        _nextFireTime = Time.time + _fireDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextFireTime)
        {
            _animator.SetBool("isAttacking", true);
            _enemy.Attack();
            _nextFireTime = Time.time + _fireDelay;
        }
    }

    public void StopAttackAnimation()
    {
        _animator.SetBool("isAttacking", false);
    }
}
