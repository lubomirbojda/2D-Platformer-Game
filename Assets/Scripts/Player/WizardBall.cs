using System;
using UnityEngine;

public class WizardBall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _wizzardRigidBody;
    private Rigidbody2D _ballRigidBody;
    private bool _isFacingRight = true;
    private float _ballSpeed = 3f;

    void Start()
    {
        _ballRigidBody = GetComponent<Rigidbody2D>();
        EnemyShot.CheckRigidbodyRotate(_wizzardRigidBody, _ballRigidBody, ref _isFacingRight);
    }

    void Update()
    {
        if (_isFacingRight)
        {
            _ballRigidBody.linearVelocityX = _ballSpeed;
        }
        else
        {
            _ballRigidBody.linearVelocityX = _ballSpeed * -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AttackEndPoint") || collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
