using UnityEngine;

public class Bird : ActiveEnemy
{
    [SerializeField] protected bool IsFacingRight;

    [SerializeField] private MoveLeftRight _movement;
    [SerializeField] private ShotAttack _shotAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _shotAttack.SetNewFireTime(Time.time);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

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
        _shotAttack.Attack();
        _shotAttack.SetNextFireTime();
    }


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag("EnemyMovePoint"))
        {
            IsFacingRight = !IsFacingRight;
            _movement.GetRigidbody2D().transform.Rotate(0, 180, 0);

        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
    }
}
