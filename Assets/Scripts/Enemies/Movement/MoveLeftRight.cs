using System.ComponentModel;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour, IEnemyMovement
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private Rigidbody2D EnemyRigidBody;

    public Rigidbody2D GetRigidbody2D()
    {
        return EnemyRigidBody;
    }

    //Setting enemy moving to left/right by bool value
    public void Move(bool facingRight, bool facingUp)
    {
        if (facingRight)
        {

            EnemyRigidBody.linearVelocity = new Vector2(MoveSpeed, EnemyRigidBody.linearVelocityY);
        }
        else
        {
            EnemyRigidBody.linearVelocity = new Vector2(MoveSpeed * -1, EnemyRigidBody.linearVelocityY);
        }
    }


}
