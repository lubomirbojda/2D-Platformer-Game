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
        if (_playerTransform.position.x < _bossRigidBody.position.x && _boss.IsFacingRight())
        {
            _bossRigidBody.transform.Rotate(0, 180, 0);
            _boss.FaceLeft();
        }

        if (_playerTransform.position.x > _bossRigidBody.position.x && !_boss.IsFacingRight())
        {
            _bossRigidBody.transform.Rotate(0, 180, 0);
            _boss.FaceRight();
        }
    }
}
