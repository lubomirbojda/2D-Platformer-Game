using UnityEngine;

public class SkeletonWhiteScript : MonoBehaviour
{
    private SkeletonWhite enemy_;
    [SerializeField] private bool isFacingRight_;
    [SerializeField] private Rigidbody2D rigidbody_;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //var enemyRigidBody = GetComponent<Rigidbody2D>();
        enemy_ = new SkeletonWhite(1.5f, 5f, 3, rigidbody_);
    }

    // Update is called once per frame
    void Update()
    {
        enemy_.Move(isFacingRight_, false);
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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy_.CanTakeDamage_ = true;
    }
}
