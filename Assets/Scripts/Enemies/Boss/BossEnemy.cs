using UnityEngine;

public class BossEnemy : ActiveEnemy
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _moveDistance;
    [SerializeField] private float _attackDistance;
    [SerializeField] private bool _isFacingRight;
    [SerializeField] private Doors _doors;

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
