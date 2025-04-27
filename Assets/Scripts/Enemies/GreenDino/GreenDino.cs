using UnityEngine;

public class GreenDino : PassiveEnemy
{
    private GameObject _shotObject;
    private GameObject _startingPosition;

    public GreenDino(
        float moveSpeed,
        float jumpSpeed,
        int health,
        Rigidbody2D enemyRigidBody,
        GameObject shot,
        GameObject startingPosition) : base(moveSpeed, jumpSpeed, health, enemyRigidBody)
    {
        _shotObject = shot;
        _startingPosition = startingPosition;
    }

    public override void Attack()
    {
        EnemyShotBasic.InstantiateShot(_shotObject, _startingPosition);
    }
}
