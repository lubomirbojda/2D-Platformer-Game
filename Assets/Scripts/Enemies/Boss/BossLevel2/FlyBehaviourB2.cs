using UnityEngine;

public class FlyBehaviourB2 : BaseBehaviourB2
{
    private bool _firstSet = false;
    //private bool _movedFirstTime = false;
    private Phase2B2 _phase2B2;

    private bool _movingToP1 = true;
    private bool _movingToP2 = false;

    private ShotAttack _shotAttack;

    private bool _phase3Started = false;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        if (!_firstSet)
        {
            _shotAttack = animator.GetComponent<ShotAttack>();
            _phase2B2 = animator.GetComponent<Phase2B2>();
            _firstSet = true;
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_phase3Started && _boss.GetHealth() <= _phase2B2.GetPhase3StartingHealth())
        {
            _phase3Started = true;
            _boss.SetMoveSpeed(_boss.GetMoveSpeed() * 2);
        }

        var point1 = _phase2B2.GetMovePoint1();
        var point2 = _phase2B2.GetMovePoint2();

        if (_bossRigidBody.position == point1.position)
        {
            
            _movingToP1 = false;
            if (!_movingToP2)
            {
                _movingToP2 = true;
                _phase2B2.SetNextMoveTime();
                RotateTowardPoint(_bossRigidBody.position.x + 1);
                _shotAttack.Attack();
            }

            //if (_phase2B2.GetNextMoveTime() < Time.time)
            //{
            //    _movingToP2 = true;             
            //}
            //_phase2B2.SetNextMoveTime();

        }


        if (_bossRigidBody.position == point2.position)
        {
            _movingToP2 = false;
            if (!_movingToP1)
            {
                _movingToP1 = true;
                _phase2B2.SetNextMoveTime();
                RotateTowardPoint(_bossRigidBody.position.x - 1);
                _shotAttack.Attack();
            }

            //if (_phase2B2.GetNextMoveTime() < Time.time)
            //{
            //    _movingToP1 = true;  
            //}
            //_phase2B2.SetNextMoveTime();
        }

        if (_phase2B2.GetNextMoveTime() < Time.time)
        {
            if (_movingToP1)
            {
                MoveToPoint(point1.position.x, point1.position.y);
            }

            if (_movingToP2)
            {
                MoveToPoint(point2.position.x, point2.position.y);
            }
        }
        

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Fly");
    }
}
