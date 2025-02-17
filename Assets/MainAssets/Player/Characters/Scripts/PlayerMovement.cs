using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    private bool isFacingRight = true;
    private float horizontalInput;
    

    private Rigidbody2D playerRigidBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(horizontalInput * moveSpeed, playerRigidBody.linearVelocityY);
        playerRigidBody.linearVelocity = direction;

        CheckFlip();
    }

    private void CheckFlip()
    {
        if ((isFacingRight && horizontalInput < 0f) || (!isFacingRight && horizontalInput > 0f))
        {
            isFacingRight = !isFacingRight;
            playerRigidBody.transform.localScale = new Vector3(playerRigidBody.transform.localScale.x * -1, playerRigidBody.transform.localScale.y, playerRigidBody.transform.localScale.z);
        }
    }

}
