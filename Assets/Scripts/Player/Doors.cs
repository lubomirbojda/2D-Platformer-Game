using UnityEngine;

public class Doors : MonoBehaviour
{
    private bool _areDoorsOpened = false;
    [SerializeField] private Animator _animator;
    [SerializeField] private Pause _pause;


    public void OpenDoors()
    {
        _animator.SetBool("open", true);
    }

    public void AllowLevelComplete()
    {
        _areDoorsOpened = true;
        _animator.SetBool("doorsOpened", true);
        _animator.SetBool("open", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _areDoorsOpened)
        {
            _pause.Vicotry();
        }
    }
}
