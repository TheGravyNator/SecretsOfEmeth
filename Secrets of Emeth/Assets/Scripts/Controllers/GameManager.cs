using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Gamestates GameState;

    public delegate void GameStateChanged(Gamestates currentGameState, Gamestates newGameState);
    public static event GameStateChanged OnGameStateChanged;

    void Start()
    {
        ChangeGameState(Gamestates.MAIN_MENU);
    }
    
    void Update()
    {
        
        
    }

    public void ChangeGameState(Gamestates newGameState)
    {
        Gamestates previousGameState = GameState;
        GameState = newGameState;
        OnGameStateChanged(previousGameState, GameState);
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
