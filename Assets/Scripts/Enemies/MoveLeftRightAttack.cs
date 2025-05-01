using UnityEngine;

public class MoveLeftRightAttack : PassiveEnemy
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _attackHitbox;
    [SerializeField] protected bool IsFacingRight;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (!_animator.GetBool("isAttacking"))
        {
            Move(IsFacingRight, false);
        }
    }

    protected override void Move(bool facingRight, bool facingUp)
    {
        if (facingRight)
        {

            EnemyRigidBody.linearVelocity = new Vector2(MoveSpeed, EnemyRigidBody.linearVelocityY);
        }
        else
        {
            EnemyRigidBody.linearVelocity = new Vector2(MoveSpeed * -1, EnemyRigidBody.linearVelocityY);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag("EnemyMovePoint"))
        {
            IsFacingRight = !IsFacingRight;

            EnemyRigidBody.transform.Rotate(0, 180, 0);

            _animator.SetBool("isAttacking", true);
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
    }

    public void EnableAttackHitbox()
    {
        _attackHitbox.SetActive(true);
    }

    public void DisableAttackHitboxAndStopAttack()
    {
        _attackHitbox.SetActive(false);
        _animator.SetBool("isAttacking", false);
    }
}
