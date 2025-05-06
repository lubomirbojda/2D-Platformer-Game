using UnityEngine;

public class WalkBehaviourB3 : BaseBehaviourB3
{
    private bool _firstSet = false;
    private Phase1B3 _phase1B2;

    //Set fields at start of animation
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        if (!_firstSet)
        {
            _phase1B2 = animator.GetComponent<Phase1B3>();
            _firstSet = true;
        }
    }

    //Switching animation and phase by algorithm
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

    //Reset animation trigger at end of animation
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Idle");
    }
}
