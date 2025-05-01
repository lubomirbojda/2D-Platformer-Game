using UnityEngine;

public class Doors : MonoBehaviour
{
    private bool _areDoorsOpened = false;
    [SerializeField] private Animator _animator;


    public void OpenDoors()
    {
        _animator.SetBool("doorsOpened", true);
    }

    public void AllowLevelComplete()
    {
        _areDoorsOpened = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_areDoorsOpened)
        {
            
        }
    }
}
