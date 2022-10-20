using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    Initial,
    Setup,
    Play,
    GameOver
}

public abstract class StatefulBehaviour : MonoBehaviour
{
    protected static GameState CurrentState { get; private set; }
    protected static Action<GameState, GameState> OnStateChange;
    protected abstract void HandleStateChange(GameState previous, GameState current);

    protected static void ChangeState(GameState state)
    {
        Debug.Log($"Requested state change from {CurrentState} to {state}");
        if (state == CurrentState) return;

        OnStateChange?.Invoke(CurrentState, state);
        CurrentState = state;
    }

    // static StatefulBehaviour()
    // {
    //     CurrentState = GameState.Initial;
    //     Debug.Log("Greetings from the static constructor for the StatefulBehaviour");
    // }

    protected virtual void Awake()
    {
        OnStateChange -= HandleStateChange;
        OnStateChange += HandleStateChange;
    }

    void OnDestroy()
    {
        OnStateChange -= HandleStateChange;
    }
}
