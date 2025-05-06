using UnityEngine;

public class AimedShot : EnemyShot
{
    [SerializeField] private GameObject _shot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        var moveDirection = CalculateMoveDirection(ActiveEnemy.GetPlayerPosition(), _shot);
        SetShotVelocity(ShotRigidBody, moveDirection);
        SetShotRotation(_shot, moveDirection);

        Destroy(gameObject, ShotLifeTime);
    }
}
