using Unity.VisualScripting;
using UnityEngine;

public class StraightShot : EnemyShot
{
    [SerializeField] private bool Up;
    [SerializeField] private bool Down;
    [SerializeField] private bool Right;
    [SerializeField] private bool Left;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Check and set direction of shot + lifetime
    private void Start()
    {
        if (Up)
        {
            ShotRigidBody.linearVelocityY = ShotSpeed;
        }
        if (Down)
        {
            ShotRigidBody.linearVelocityY = ShotSpeed * -1;
        }
        if (Right)
        {
            ShotRigidBody.linearVelocityX = ShotSpeed;
        }
        if (Left)
        {
            ShotRigidBody.linearVelocityX = ShotSpeed * -1;
        }

        Destroy(gameObject, ShotLifeTime);
    }

}
