using UnityEngine;

public class Bird : ActiveEnemy
{
    //[SerializeField] protected GameObject ShotObject;
    //[SerializeField] protected GameObject StartingPosition;
    //[SerializeField] protected float FireDelay;
    [SerializeField] protected bool IsFacingRight;
   // protected float NextFireTime;

    [SerializeField] private MoveLeftRight _movement;
    [SerializeField] private ShotAttack _shotAttack;

    private void Start()
    {
        _shotAttack.SetNewFireTime(Time.time);
    }

    protected override void Update()
    {
        base.Update();

        //Move(IsFacingRight, false);
        _movement.Move(IsFacingRight, false);

        if (Time.time > _shotAttack.GetNextFireTime())
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
        //Attack();

        _shotAttack.Attack();
        _shotAttack.SetNextFireTime();

        //NextFireTime = Time.time + FireDelay;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag("EnemyMovePoint"))
        {
            IsFacingRight = !IsFacingRight;

            //EnemyRigidBody.transform.Rotate(0, 180, 0);
            _movement.GetRigidbody2D().transform.Rotate(0, 180, 0);

        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
    }
}
