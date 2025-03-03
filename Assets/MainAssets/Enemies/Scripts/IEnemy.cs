using UnityEngine;

public interface IEnemy
{
    void Move(bool facingRight, bool facingUp);
    void Attack();
    void TakeDamage(int damage);
}
