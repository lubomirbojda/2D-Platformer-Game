using UnityEngine;

public class EnemyShot : MonoBehaviour 
{
    [SerializeField] protected Rigidbody2D EnemyRigidBody;
    [SerializeField] protected Rigidbody2D ShotRigidBody;
    [SerializeField] protected float ShotSpeed;
    [SerializeField] protected float ShotLifeTime;

    // Instantiate object of shot on position of sent GameObject
    public static void InstantiateShot(GameObject shotObject, GameObject startingPosition)
    {
        var shot_ = Instantiate(shotObject, startingPosition.transform.position, Quaternion.identity);
        shot_.SetActive(true);
    }

    //Return Vector3 as shot move direction
    protected Vector3 CalculateMoveDirection(Vector3 targetPosition, GameObject shot)
    {       
        var moveDirection = (targetPosition - shot.transform.position).normalized * ShotSpeed;
        return moveDirection;
    }

    //Set velocity of shot, so shot will be moving in way of direction
    protected static void SetShotVelocity(Rigidbody2D shotRigidbody, Vector3 moveDirection)
    {
        var velocity = new Vector2(moveDirection.x, moveDirection.y);
        shotRigidbody.linearVelocity = velocity;
    }

    //Set rotation of shot object based on direction
    protected static void SetShotRotation(GameObject shot, Vector3 direction)
    {
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        shot.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

}
