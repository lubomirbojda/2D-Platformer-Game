using UnityEngine;

public class ActiveEnemy : Enemy
{
    [SerializeField] protected ActiveZone EnemyActiveZone;
    [SerializeField] protected Animator Animator;

    protected void StartAttackAnimation()
    {
        Animator.SetBool("isAttacking", true);
    }

    protected void StopAttackAnimation()
    {
        Animator.SetBool("isAttacking", false);
    }

    public static Vector3 GetPlayerPosition()
    {
        var playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        return playerPosition;
    }
}
