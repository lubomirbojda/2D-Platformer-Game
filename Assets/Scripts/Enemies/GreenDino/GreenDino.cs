using UnityEngine;

public class GreenDino : PassiveEnemy
{
    [SerializeField] protected GameObject ShotObject;
    [SerializeField] protected GameObject StartingPosition;

    public override void Attack()
    {
        EnemyShot.InstantiateShot(ShotObject, StartingPosition);
    }
}
