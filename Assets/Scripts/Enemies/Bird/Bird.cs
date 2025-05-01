using UnityEngine;

public class Bird : ActiveEnemy
{
    [SerializeField] protected GameObject ShotObject;
    [SerializeField] protected GameObject StartingPosition;
    [SerializeField] protected float FireDelay;
    [SerializeField] protected bool IsFacingRight;
    protected float NextFireTime;

    private void Start()
    {
        NextFireTime = Time.time;
    }

    protected override void Attack()
    {
        EnemyShot.InstantiateShot(ShotObject, StartingPosition);
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

    protected override void Update()
    {
        base.Update();

        Move(IsFacingRight, false);

        if (Time.time > NextFireTime)
        {
            if (EnemyActiveZone.IsActive())
            {
                MakeAttack();
            }
            else
            {
                StopAttackAnimation();
            }
        }
    }

    private void MakeAttack()
    {
        StartAttackAnimation();
        Attack();
        NextFireTime = Time.time + FireDelay;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag("EnemyMovePoint"))
        {
            IsFacingRight = !IsFacingRight;

            EnemyRigidBody.transform.Rotate(0, 180, 0);

        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
    }
}
