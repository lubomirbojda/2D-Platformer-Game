using UnityEngine;

public class AimedShot : EnemyShot
{
    [SerializeField] private GameObject _shot;

    private void Start()
    {
        var moveDirection = CalculateMoveDirection(ActiveEnemy.GetPlayerPosition(), _shot);
        SetShotVelocity(ShotRigidBody, moveDirection);
        SetShotRotation(_shot, moveDirection);

        Destroy(gameObject, ShotLifeTime);
    }
}
