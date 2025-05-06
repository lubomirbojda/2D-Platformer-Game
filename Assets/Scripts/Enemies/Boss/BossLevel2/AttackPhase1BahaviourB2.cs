using UnityEngine;

public class AttackPhase1BahaviourB2 : BaseBehaviourB2
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Phase1");
    }
}
