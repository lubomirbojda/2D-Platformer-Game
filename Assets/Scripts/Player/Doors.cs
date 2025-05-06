using UnityEngine;

public class Doors : MonoBehaviour
{
    private bool _areDoorsOpened = false;
    [SerializeField] private Animator _animator;
    [SerializeField] private Pause _pause;

    //Play opening animation of doors
    public void OpenDoors()
    {
        _animator.SetBool("open", true);
    }

    //Doors will stay opened so player can complete level
    public void AllowLevelComplete()
    {
        _areDoorsOpened = true;
        _animator.SetBool("doorsOpened", true);
        _animator.SetBool("open", false);
    }

    //When player collide with doors, level ends
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _areDoorsOpened)
        {
            _pause.Vicotry();
        }
    }
}
