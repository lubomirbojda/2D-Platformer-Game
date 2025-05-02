using UnityEngine;

public class ShotAttack : MonoBehaviour, IEnemyAttack
{
    [SerializeField] private GameObject ShotObject;
    [SerializeField] private GameObject StartingPosition;
    [SerializeField] private float FireDelay;
    private float NextFireTime;

    public void Attack()
    {
        EnemyShot.InstantiateShot(ShotObject, StartingPosition);
    }

    public void SetNewFireTime(float newTime)
    {
        NextFireTime = newTime;
    }

    public void SetNextFireTime()
    {
        NextFireTime = Time.time + FireDelay;
    }

    public float GetNextFireTime()
    {
        return NextFireTime;
    }
}

