using UnityEngine;

public class AttackPhase1BahaviourB3 : BaseBehaviourB3
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    //Reset animation trigger at end of animation
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Phase1");
    }
}
