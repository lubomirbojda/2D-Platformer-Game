using UnityEngine;

public class PlayerJumpScript : MonoBehaviour
{

    [SerializeField] private float _jumpSpeed;
    private bool _isInJump = false;
    private bool _isGrounded = true;

    private Rigidbody2D _playerRB;

    private Animator _animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerRB = GetComponentInParent<Rigidbody2D>();
        _animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            _isInJump = false;
            _isGrounded = true;
            _animator.SetBool("isJumping", _isInJump);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            _isGrounded = false;
            _isInJump = true;
        } 
    }

    //Method called on player jump input (spacebar)
    public void OnJump()
    {
        if (Pause.GameIsPaused)
            return;

        if (!_isInJump && _isGrounded)
        {
            _playerRB.linearVelocityY = _jumpSpeed;
            _isInJump = true;
            _isGrounded = false;
            _animator.SetBool("isJumping", _isInJump);
        }  
    }
}
