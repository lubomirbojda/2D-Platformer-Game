using UnityEngine;

public class PlayerJumpScript : MonoBehaviour
{

    private float jumpSpeed = 10f;
    private bool isInJump = false;
    private bool isGrounded = true;

    private Rigidbody2D playerRB;
    //private BoxCollider2D jumpCollider;

    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponentInParent<Rigidbody2D>();
        //jumpCollider = GetComponent<BoxCollider2D>();
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInJump = false;
        isGrounded = true;
        animator.SetBool("isJumping", isInJump);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }

    public void OnJump()
    {
        if (!isInJump && isGrounded)
        {
            playerRB.linearVelocityY = jumpSpeed;
            isInJump = true;
            isGrounded = false;
            animator.SetBool("isJumping", isInJump);
        }  
    }
}
