using UnityEngine;

public class BaseBossBehaviour : StateMachineBehaviour
{
    protected Transform _playerTransform;
    protected Rigidbody2D _bossRigidBody;
    protected BossEnemy _boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _bossRigidBody = animator.GetComponent<Rigidbody2D>();
        _boss = animator.GetComponent<BossEnemy>();
    }

    protected void RotateTowardPlayer()
    {
        RotateTowardPoint(_playerTransform.position.x);
    }

    protected void RotateTowardPoint(float x)
    {
        if (x < _bossRigidBody.position.x && _boss.IsFacingRight())
        {
            _bossRigidBody.transform.Rotate(0, 180, 0);
            _boss.FaceLeft();
        }

        if (x > _bossRigidBody.position.x && !_boss.IsFacingRight())
        {
            _bossRigidBody.transform.Rotate(0, 180, 0);
            _boss.FaceRight();
        }
    }

    protected void MoveToPoint(float x, float y)
    {
        RotateTowardPoint(x);
        Vector2 target = new Vector2(x, y);
        Vector2 newPos = Vector2.MoveTowards(_bossRigidBody.position, target, _boss.GetMoveSpeed() * Time.fixedDeltaTime);
        _bossRigidBody.MovePosition(newPos);
    }

    protected void FollowPlayer()
    {
        MoveToPoint(_playerTransform.position.x, _bossRigidBody.position.y);
    }

    protected float GetPlayerDistance()
    {
        return Vector3.Distance(_playerTransform.position, _bossRigidBody.position);
    }
}
