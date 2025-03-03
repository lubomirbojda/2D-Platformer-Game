using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject attackHitbox_;
    private bool isFacingRight = true;
    private float horizontalInput;

    private bool isInAttack = false;
    

    private Rigidbody2D playerRigidBody;
    private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        
        Vector2 direction = new Vector2(horizontalInput * moveSpeed, playerRigidBody.linearVelocityY);
        playerRigidBody.linearVelocity = direction;
        animator.SetFloat("xVelocity", Mathf.Abs(playerRigidBody.linearVelocityX));
        animator.SetFloat("yVelocity", playerRigidBody.linearVelocityY);
            
    }

    private void CheckFlip()
    {
        if ((isFacingRight && horizontalInput < 0f) || (!isFacingRight && horizontalInput > 0f))
        {
            isFacingRight = !isFacingRight;
            playerRigidBody.transform.localScale = 
                new Vector3(playerRigidBody.transform.localScale.x * -1, 
                playerRigidBody.transform.localScale.y, 
                playerRigidBody.transform.localScale.z);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
        CheckFlip();
    }

    public void OnAttack()
    {
        if (!isInAttack && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
        {
            attackHitbox_.SetActive(true);
            isInAttack = true;
            animator.SetBool("isAttacking", isInAttack);    
        }
    }

    public void EndAttack()
    {
        attackHitbox_.SetActive(false);
        isInAttack = false;
        animator.SetBool("isAttacking", isInAttack); 
    }
}
