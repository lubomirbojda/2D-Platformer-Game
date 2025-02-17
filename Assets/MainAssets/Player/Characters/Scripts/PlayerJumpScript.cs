using UnityEngine;

public class PlayerJumpScript : MonoBehaviour
{

    private float jumpSpeed = 10f;
    private bool isInJump = false;

    private Rigidbody2D playerRB;
    private BoxCollider2D jumpCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponentInParent<Rigidbody2D>();
        jumpCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isInJump)
        {
            playerRB.linearVelocityY = jumpSpeed;
            isInJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInJump = false;
    }
}
