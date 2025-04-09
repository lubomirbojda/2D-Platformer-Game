using UnityEngine;

public class SkeletonWhiteWithAttack : MonoBehaviour
{
    private SkeletonWhite enemy_;
    [SerializeField] private bool isFacingRight_;
    [SerializeField] private Rigidbody2D rigidbody_;
    [SerializeField] private Animator animator_;
    [SerializeField] private GameObject _attackHitbox;
    void Start()
    {
        //var enemyRigidBody = GetComponent<Rigidbody2D>();
        enemy_ = new SkeletonWhite(1.5f, 5f, 3, rigidbody_);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!animator_.GetBool("isAttacking"))
        {
            enemy_.Move(isFacingRight_, false);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            enemy_.TakeDamage(1);
            enemy_.CanTakeDamage_ = false;
            Debug.Log(enemy_.Health_);
        }

        if (collision.CompareTag("EnemyMovePoint"))
        {
            isFacingRight_ = !isFacingRight_;

            enemy_.enemyRigidBody_.transform.Rotate(0, 180, 0);

            animator_.SetBool("isAttacking", true);
        }
    }

    public void EnableAttackHitbox()
    {
        _attackHitbox.SetActive(true);
    }

    public void DisableAttackHitboxAndStopAttack()
    {
        _attackHitbox.SetActive(false);
        animator_.SetBool("isAttacking", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy_.CanTakeDamage_ = true;
    }
}
