using UnityEditor;
using UnityEngine;

public class EnemyShot : MonoBehaviour 
{
    [SerializeField] protected Rigidbody2D EnemyRigidBody;
    [SerializeField] protected Rigidbody2D ShotRigidBody;
    [SerializeField] protected float ShotSpeed;
    [SerializeField] protected float ShotLifeTime;
    protected bool IsFacingRight = true;

    protected virtual void Start()
    {
        CheckRigidbodyRotate(EnemyRigidBody, ShotRigidBody, ref IsFacingRight);
    }

    public static void CheckRigidbodyRotate(Rigidbody2D rotatedBody, Rigidbody2D bodyToRotate, ref bool isFacingRight)
    {
        if (rotatedBody.transform.localScale.x < 0)
        {
            isFacingRight = false;
            bodyToRotate.transform.localScale = new Vector3(bodyToRotate.transform.localScale.x * -1,
                                                            bodyToRotate.transform.localScale.y,
                                                            bodyToRotate.transform.localScale.z);
        }
    }

    public static void InstantiateShot(GameObject shotObject, GameObject startingPosition)
    {
        var shot_ = Instantiate(shotObject, startingPosition.transform.position, Quaternion.identity);
        shot_.SetActive(true);
    }


}
