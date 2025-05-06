using UnityEngine;

public class IdleBehaviourB2 : BaseBossBehaviour
{
    //If player is close enough to enemy, change animation
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
