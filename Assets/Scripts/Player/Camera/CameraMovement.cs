using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject _player;

    private Vector3 _velocity = Vector3.zero;

    [SerializeField] private float _xMaxLimit;
    [SerializeField] private float _xMinLimit;
    [SerializeField] private float _yMaxLimit;
    [SerializeField] private float _yMinLimit;
    private bool _isLocked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    //Set the camera position by player position - if is on maximum on minimum, camera dont move
    void Update()
    {

        if (_player != null)
        {
            if (_isLocked)
            {
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(_xMaxLimit, 0, -10), ref _velocity, 0.5f);
            }
            else
            {
                Vector3 playerPosition = _player.transform.position;
                playerPosition = new Vector3(Mathf.Clamp(playerPosition.x, _xMinLimit, _xMaxLimit),
                    Mathf.Clamp(playerPosition.y, _yMinLimit, _yMaxLimit),
                    -10);
                transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref _velocity, 0.2f);
            }   
        }
        else
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void LockOnMaximum()
    {
        _isLocked = true;
    }

}
