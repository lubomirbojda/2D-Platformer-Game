using UnityEngine;

public class BossEnemy : ActiveEnemy
{
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _moveDistance;
    [SerializeField] protected float _attackDistance;
    [SerializeField] protected bool _isFacingRight;
    [SerializeField] protected Doors _doors;

    protected override void TakeDamage()
    {
        base.TakeDamage();

        if (IsDead)
        {
            _doors.OpenDoors();
        }
    }

    public float GetMoveSpeed()
    {
        return _moveSpeed;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }

    public float GetMoveDistance()
    {
        return _moveDistance;
    }

    public void SetMoveDistance(float moveDistance)
    {
        _moveDistance = moveDistance;
    }

    public float GetAttackDistance()
    {
        return _attackDistance;
    }

    public void SetAttackDistance(float attackDistance)
    {
        _attackDistance = attackDistance;
    }

    public bool IsFacingRight()
    {
        return _isFacingRight;
    }

    public void FaceLeft()
    {
        _isFacingRight = false;
    }

    public void FaceRight()
    {
        _isFacingRight = true;
    }
}
