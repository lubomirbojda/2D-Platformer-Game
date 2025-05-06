using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealtBar : MonoBehaviour
{
    [SerializeField] private GameObject _heart;
    private PlayerGetHit _playerGetHitScript;
    private int _currentHealt = 0;

    [SerializeField] private List<Heart> _hearts;
    private bool _defaultHeartSet = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        _playerGetHitScript = player.GetComponentInChildren<PlayerGetHit>();

    }

    // Update is called once per frame
    void Update()
    {
        var currentHP = _playerGetHitScript.GetActualHealth();

        if (!_defaultHeartSet)
        {
            for (int i = currentHP; i < _hearts.Count; i++)
            {
                _hearts[i].RemoveHeartFully();
            }
            _defaultHeartSet = true;
        }

        if (_currentHealt != currentHP)
        {
            _currentHealt = currentHP;

            for (int i = _currentHealt; i < _playerGetHitScript.GetMaxhealt(); i++)
            {
                _hearts[i].LoseThisHeart();
            }
        }
    }
}
