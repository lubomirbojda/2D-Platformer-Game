using UnityEngine;

public interface IEnemyMovement
{
    void Move(bool facingRight, bool facingUp);
    Rigidbody2D GetRigidbody2D();
}
