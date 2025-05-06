using System;
using UnityEngine;

public class WizardBall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _wizzardRigidBody;
    private Rigidbody2D _ballRigidBody;
    private bool _isFacingRight = true;
    private float _ballSpeed = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _ballRigidBody = GetComponent<Rigidbody2D>();
        CheckRigidbodyRotate(_wizzardRigidBody, _ballRigidBody);
    }

    //Check rotation of player and set same rotation on ball shot
    private void CheckRigidbodyRotate(Rigidbody2D rotatedBody, Rigidbody2D bodyToRotate)
    {
        if (rotatedBody.transform.localScale.x < 0)
        {
            _isFacingRight = false;
            bodyToRotate.transform.localScale = new Vector3(bodyToRotate.transform.localScale.x * -1,
                                                            bodyToRotate.transform.localScale.y,
                                                            bodyToRotate.transform.localScale.z);
        }
    }

    // Update is called once per frame
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
