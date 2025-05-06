using UnityEngine;

public class WalkBehaviourB1 : BaseBossBehaviour
{
    private int _phase2HealthStart; 
    private float _nextShotDelay = 2.5f;
    private float _nextFireTime;
    private bool _firstSet = false;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        if (!_firstSet)
        {
            _phase2HealthStart = _boss.GetMaxHealth() / 2;
            _nextFireTime = Time.time + 1f;
            _firstSet = true;
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_boss.GetHealth() <= _phase2HealthStart)
        {
            if (_nextFireTime < Time.time)
            {
                animator.SetTrigger("Shoot");
                _nextFireTime = Time.time + _nextShotDelay;
            }
            else
            {
                FollowPlayer();
            }

            return;
        }

        var playerDist = GetPlayerDistance();
        if (playerDist > _boss.GetMoveDistance())
        {
            animator.SetTrigger("Idle");
            return;
        }
        if (playerDist <= _boss.GetAttackDistance())
        {
            animator.SetTrigger("Attack");
            return;
        }

        FollowPlayer();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Idle");
    }

}
