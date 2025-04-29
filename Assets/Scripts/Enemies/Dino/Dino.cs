using UnityEngine;

public class Dino : ActiveEnemy
{
    [SerializeField] protected GameObject ShotObject;
    [SerializeField] protected GameObject StartingPosition;
    [SerializeField] protected float FireDelay;
    protected float NextFireTime;

    public override void Attack()
    {
        EnemyShot.InstantiateShot(ShotObject, StartingPosition);
    }

}
