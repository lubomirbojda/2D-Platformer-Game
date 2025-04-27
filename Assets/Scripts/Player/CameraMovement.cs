using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform _playerTransform;

    private Vector3 _velocity = Vector3.zero;

    [SerializeField] private float _xMaxLimit;
    [SerializeField] private float _xMinLimit;
    [SerializeField] private float _yMaxLimit;
    [SerializeField] private float _yMinLimit;

    private void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = _playerTransform.position;
        playerPosition = new Vector3(Mathf.Clamp(playerPosition.x, _xMinLimit, _xMaxLimit), 
            Mathf.Clamp(playerPosition.y, _yMinLimit, _yMaxLimit),
            -10);
        transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref _velocity, 0.2f);
    }
}
