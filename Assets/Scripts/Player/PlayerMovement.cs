using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private PlayerAttack _playerAttack;
    private bool _isFacingRight = true;
    private float _horizontalInput;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _attackAudioClip;

    private bool _isInAttack = false;
    

    private Rigidbody2D _playerRigidBody;
    private Animator _animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {    
        Vector2 direction = new Vector2(_horizontalInput * _moveSpeed, _playerRigidBody.linearVelocityY);
        _playerRigidBody.linearVelocity = direction;
        _animator.SetFloat("xVelocity", Mathf.Abs(_playerRigidBody.linearVelocityX));
        _animator.SetFloat("yVelocity", _playerRigidBody.linearVelocityY);
    }

    private void CheckFlip()
    {
        if ((_isFacingRight && _horizontalInput < 0f) || (!_isFacingRight && _horizontalInput > 0f))
        {
            _isFacingRight = !_isFacingRight;
            _playerRigidBody.transform.localScale = 
                new Vector3(_playerRigidBody.transform.localScale.x * -1, 
                _playerRigidBody.transform.localScale.y, 
                _playerRigidBody.transform.localScale.z);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (Pause.GameIsPaused)
            return;

        _horizontalInput = context.ReadValue<Vector2>().x;
        CheckFlip();
    }

    public void OnAttack()
    {
        if (Pause.GameIsPaused)
            return;

        if (!_isInAttack && !_animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
        {
            _playerAttack.Attack();
            _isInAttack = true;
            _animator.SetBool("isAttacking", _isInAttack);
            AudioPlay.PlayAudioClip(_audioSource, _attackAudioClip);
        }
    }

    public void EndAttack()
    {
        _playerAttack.EndAttack();
        _isInAttack = false;
        _animator.SetBool("isAttacking", _isInAttack); 
    }

}
