using UnityEditor.AnimatedValues;
using UnityEngine;

public class IdleBehaviourB1 : BaseBossBehaviour
{

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(_playerTransform.position, _bossRigidBody.position) <= _boss.GetMoveDistance())
        {
            animator.SetTrigger("Walk");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Walk");
    }

}
