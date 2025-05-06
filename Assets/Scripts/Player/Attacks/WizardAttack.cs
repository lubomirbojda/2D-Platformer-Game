using UnityEngine;

public class WizardAttack : PlayerAttack
{
    [SerializeField] private GameObject _attackPosition;
    [SerializeField] private GameObject _wizardBall;

    //Instantiate wizard ball at given position
    public override void Attack()
    {
        var ball = Instantiate(_wizardBall, _attackPosition.transform.position, Quaternion.identity);
        ball.SetActive(true);
    }
}
