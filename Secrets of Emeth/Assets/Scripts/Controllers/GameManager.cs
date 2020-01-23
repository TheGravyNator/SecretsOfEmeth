using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager instance;

    private GameManager() { }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    public Gamestates previousGameState;
    public Gamestates GameState;

    public delegate void GameStateChanged(Gamestates currentGameState, Gamestates newGameState);
    public static event GameStateChanged OnGameStateChanged;

    void Start()
    {
        ChangeGameState(Gamestates.MAIN_MENU);
    }

    public void ChangeGameState(Gamestates newGameState)
    {
        previousGameState = GameState;
        Gamestates currentGameState = GameState;
        GameState = newGameState;
        OnGameStateChanged(currentGameState, GameState);
    }
}

public enum Gamestates
{
    MAIN_MENU,
    PAUSE_MENU,
    INTERACTING,
    OVERWORLD,
    INTERIOR,
    IN_BATTLE
}
