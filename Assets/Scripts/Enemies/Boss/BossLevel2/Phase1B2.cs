using UnityEngine;

public class Phase1B2 : MonoBehaviour
{
    [SerializeField] private GameObject _attackHitbox;
    [SerializeField] private int _phase2StartingHealth;

    public void ActivateAttackHitbox()
    {
        _attackHitbox.SetActive(true);
    }

    public void DeactivateAttackHitbox()
    {
        _attackHitbox.SetActive(false);
    }

    public int GetPhase2StartingHealth()
    {
        return _phase2StartingHealth;
    }
}
