using UnityEngine;

public class SkeletonWhiteNoAttack : SkeletonWhite
{

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Move(IsFacingRight, false);
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
