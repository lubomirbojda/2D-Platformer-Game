using UnityEngine;

public class GreenDitoShot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _dinoRigidBody;
    [SerializeField] private float _shotSpeed;
    [SerializeField] private GreenDinoStraighAttack _dinoStraighAttack;
    private Rigidbody2D _shotRigidBody;
    private bool _isFacingRight = true;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _shotRigidBody = GetComponent<Rigidbody2D>();
        EnemyShotBasic.CheckRigidbodyRotate(_dinoRigidBody, _shotRigidBody, ref _isFacingRight);

        if (_isFacingRight)
        {
            _shotRigidBody.linearVelocityX = _shotSpeed;
        }
        else
        {
            _shotRigidBody.linearVelocityX = _shotSpeed * -1;
        }

        Destroy(gameObject, 1.5f);
    }

    private void OnDestroy()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
