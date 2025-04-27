using UnityEngine;

public class GreenDinoStraighAttack : GreenDino
{
    [SerializeField] private float _fireDelay;
    private float _nextFireTime;
    [SerializeField] private Animator _animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator.SetBool("isAttacking", true);
        Attack();
        _nextFireTime = Time.time + _fireDelay;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (Time.time > _nextFireTime)
        {
            _animator.SetBool("isAttacking", true);
            Attack();
            _nextFireTime = Time.time + _fireDelay;
        }
    }

    public void StopAttackAnimation()
    {
        _animator.SetBool("isAttacking", false);
    }
}
