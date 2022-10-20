using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField]
    EnemySpawner _spawner;

    [SerializeField]
    TMP_Text _text;

    int _currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        _spawner.Scored += (int score) => UpdateScore(score);
    }

    void UpdateScore(int score)
    {
        _currentScore += score;
        _text.text = _currentScore.ToString("D4");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
