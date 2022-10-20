using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : StatefulBehaviour
{
    [SerializeField]
    EnemySpawner _spawner;

    [SerializeField]
    TMP_Text _text;

    int _currentScore = 0;

    void Start()
    {
        _spawner.Scored += (int score) => AddScore(score);
    }

    void AddScore(int score)
    {
        _currentScore += score;
        _text.text = _currentScore.ToString("D4");
    }

    protected override void HandleStateChange(GameState previous, GameState current)
    {
        if (current == GameState.Setup)
        {
            _currentScore = 0;
            AddScore(0);
        }
    }
}
