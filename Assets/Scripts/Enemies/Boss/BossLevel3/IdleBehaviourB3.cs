using UnityEngine;

public class IdleBehaviourB3 : BaseBehaviourB3
{

    //Set animation to walk if player is close enough
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(_playerTransform.position, _bossRigidBody.position) <= _boss.GetMoveDistance())
        {
            animator.SetTrigger("Walk");
        }
    }

    //Reset animation trigger at end of animation
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Walk");
    }
}
