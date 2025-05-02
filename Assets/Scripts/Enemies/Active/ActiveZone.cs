using UnityEngine;

public class ActiveZone : MonoBehaviour
{
    private bool _isActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isActive = false;
        }
    }

    public bool IsActive()
    {
        return _isActive;
    }
}
