using UnityEditor;
using UnityEngine;

public class EnemyShotBasic : MonoBehaviour 
{
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
