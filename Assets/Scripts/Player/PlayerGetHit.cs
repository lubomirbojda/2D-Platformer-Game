using UnityEngine;

public class PlayerGetHit : MonoBehaviour
{
    [SerializeField] private int _playerHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _playerHealth -= 1;
            Debug.Log("Dostal si hit");
            Debug.Log("Hp: " + _playerHealth);
        }

    }
}
