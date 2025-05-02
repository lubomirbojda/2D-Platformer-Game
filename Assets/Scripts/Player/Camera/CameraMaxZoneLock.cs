using UnityEngine;

public class CameraMaxZoneLock : MonoBehaviour
{
    [SerializeField] private CameraMovement _cameraMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _cameraMovement.LockOnMaximum();
        }
    }
}
