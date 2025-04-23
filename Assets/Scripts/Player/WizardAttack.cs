using UnityEngine;

public class WizardAttack : PlayerAttack
{
    [SerializeField] private GameObject attackPosition_;
    [SerializeField] private GameObject wizardBall_;

    public override void Attack()
    {
        var ball = Instantiate(wizardBall_, attackPosition_.transform.position, Quaternion.identity);
        ball.SetActive(true);
    }
}
