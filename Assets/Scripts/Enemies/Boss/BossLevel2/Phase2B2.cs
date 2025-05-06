using UnityEngine;

public class Phase2B2 : MonoBehaviour
{
    private float _nextMoveDelay = 2f;
    private float _nextMoveTime;
    [SerializeField] private int _phase3StartingHealth;
    [SerializeField] private Rigidbody2D _movePoint1;
    [SerializeField] private Rigidbody2D _movePoint2;

    private void Start()
    {
        SetNextMoveTime();
    }

    public float GetNextMoveTime()
    {
        return _nextMoveTime;
    }

    public void SetNextMoveTime()
    {
        _nextMoveTime = Time.time + _nextMoveDelay;
    }

    public int GetPhase3StartingHealth()
    {
        return _phase3StartingHealth;
    }

    public Rigidbody2D GetMovePoint1()
    {
        return _movePoint1;
    }

    public Rigidbody2D GetMovePoint2()
    {
        return _movePoint2;
    }

}
