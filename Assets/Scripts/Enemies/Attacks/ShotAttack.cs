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

    //Set next fire time on sent time(float)
    public void SetNewFireTime(float newTime)
    {
        NextFireTime = newTime;
    }

    //Auto set next fire time based on float SerializeField value
    public void SetNextFireTime()
    {
        NextFireTime = Time.time + FireDelay;
    }

    
    //Return time of next fire
    public float GetNextFireTime()
    {
        return NextFireTime;
    }
}

