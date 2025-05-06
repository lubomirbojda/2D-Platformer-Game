using UnityEngine;

public class BossLevel1OpenDoors : MonoBehaviour
{
    [SerializeField] private Doors _doors;
    [SerializeField] private AimedShootingEnemy _enemy;
    private bool _opened = false;

    // Update is called once per frame
    //Check if boss is dead, so doors can open
    private void Update()
    {
        if (_enemy.IsEnemyDead() && !_opened)
        {
            _doors.OpenDoors();
            _opened = true;
        }
    }
}
