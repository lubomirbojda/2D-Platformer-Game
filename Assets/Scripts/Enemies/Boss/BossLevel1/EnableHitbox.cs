using UnityEngine;

public class EnableHitbox : MonoBehaviour
{
    [SerializeField] private GameObject _attackHitbox;

    public void EnableAttackHitbox()
    {
        _attackHitbox.SetActive(true);
    }

    public void DisableAttackHitboxAndStopAttack()
    {
        _attackHitbox.SetActive(false);
    }
}
