using UnityEngine;

public class WalkBehaviourB2 : BaseBehaviourB2
{
    private bool _firstSet = false;
    private Phase1B2 _phase1B2;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        if (!_firstSet)
        {
            _phase1B2 = animator.GetComponent<Phase1B2>();
            _firstSet = true;
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_boss.GetHealth() <= _phase1B2.GetPhase2StartingHealth())
        {
            animator.SetTrigger("Fly");
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
            animator.SetTrigger("Phase1");
            return;
        }

        FollowPlayer();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Idle");
    }
}
