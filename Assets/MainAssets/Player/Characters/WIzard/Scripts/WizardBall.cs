using System;
using UnityEngine;

public class WizardBall : MonoBehaviour
{
    [SerializeField] Rigidbody2D WizzardRigidBody_;
    private Rigidbody2D ballRigidBody;
    private bool isFacingRight = true;
    private float ballSpeed = 3f;
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
        if (WizzardRigidBody_.transform.localScale.x < 0)
        {
            isFacingRight = false;
            ballRigidBody.transform.localScale = new Vector3(ballRigidBody.transform.localScale.x * -1,
                                                            ballRigidBody.transform.localScale.y,
                                                            ballRigidBody.transform.localScale.z); 
        }  
    }

    void Update()
    {
        if (isFacingRight)
        {
            ballRigidBody.linearVelocityX = ballSpeed;
        }
        else
        {
            ballRigidBody.linearVelocityX = ballSpeed * -1;
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
