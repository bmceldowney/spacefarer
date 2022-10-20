using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : StatefulBehaviour
{
    [SerializeField]
    GameObject _gameOverScreen;
    [SerializeField]
    GameObject _startScreen;
    [SerializeField]
    GameObject _readyScreen;

    protected override void HandleStateChange(GameState previous, GameState current)
    {
        _gameOverScreen.SetActive(false);
        _startScreen.SetActive(false);
        _readyScreen.SetActive(false);

        if (current == GameState.GameOver)
        {
            _gameOverScreen.SetActive(true);
        }
        
        if (current == GameState.Initial) 
        {
            _startScreen.SetActive(true);
        }

        if (current == GameState.Setup)
        {
            _readyScreen.SetActive(true);
        }
    }

    void Start()
    {
        _startScreen.SetActive(true);
    }

    public void OnRestartPressed()
    {
        StatefulBehaviour.ChangeState(GameState.Setup);
    }

    public void OnStartPressed()
    {
        StatefulBehaviour.ChangeState(GameState.Setup);
    }
}
