using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipHealth : MonoBehaviour, IScorable
{
    [SerializeField]
    int _maxHealth = 3;
    [SerializeField]
    int _currentHealth = 3;
    [SerializeField]
    Heart[] _hearts;

    void Start()
    {
        SetScore(_currentHealth);
    }

    public int GetScore()
    {
        return _currentHealth;
    }

    public void SetScore(int score)
    {
        _currentHealth = score;
        for (int i = 0; i < _hearts.Length; i++)
        {
            _hearts[i].SetValue(i < score);
        }
    }

    public void Reset()
    {
        SetScore(_maxHealth);
    }
}
