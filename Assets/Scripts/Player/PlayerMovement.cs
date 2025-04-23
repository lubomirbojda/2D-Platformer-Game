using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MoveSpeed_;
    [SerializeField] private PlayerAttack PlayerAttack_;
    private bool IsFacingRight_ = true;
    private float HorizontalInput_;

    [SerializeField] private AudioPlay AudioPlay_;
    [SerializeField] private AudioClip AttackAudioClip_;

    private bool IsInAttack_ = false;
    

    private Rigidbody2D PlayerRigidBody_;
    private Animator Animator_;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRigidBody_ = GetComponent<Rigidbody2D>();
        Animator_ = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {    
        Vector2 direction = new Vector2(HorizontalInput_ * MoveSpeed_, PlayerRigidBody_.linearVelocityY);
        PlayerRigidBody_.linearVelocity = direction;
        Animator_.SetFloat("xVelocity", Mathf.Abs(PlayerRigidBody_.linearVelocityX));
        Animator_.SetFloat("yVelocity", PlayerRigidBody_.linearVelocityY);
    }

    private void CheckFlip()
    {
        if ((IsFacingRight_ && HorizontalInput_ < 0f) || (!IsFacingRight_ && HorizontalInput_ > 0f))
        {
            IsFacingRight_ = !IsFacingRight_;
            PlayerRigidBody_.transform.localScale = 
                new Vector3(PlayerRigidBody_.transform.localScale.x * -1, 
                PlayerRigidBody_.transform.localScale.y, 
                PlayerRigidBody_.transform.localScale.z);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        HorizontalInput_ = context.ReadValue<Vector2>().x;
        CheckFlip();
    }

    public void OnAttack()
    {
        if (!IsInAttack_ && !Animator_.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
        {
            PlayerAttack_.Attack();
            IsInAttack_ = true;
            Animator_.SetBool("isAttacking", IsInAttack_);
            AudioPlay_.PlayAudioClip(AttackAudioClip_);
        }
    }

    public void EndAttack()
    {
        PlayerAttack_.EndAttack();
        IsInAttack_ = false;
        Animator_.SetBool("isAttacking", IsInAttack_); 
    }

}
