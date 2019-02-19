using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System;
using BTScriptableObject;

namespace Interfaces
{
    public interface IGameManager : IService
    {
        event Action GameStarted;
        event Action GamePaused;
        event Action GameUnpaused;
        event Action<int> GamesPlayedAdd;
        event Action ReplayGame;

        void OnGameStarted();

        void PauseGame();

        void UnPauseGame();

        void OnReplayGame();

        void OnUpdate();

        void UpdateGameState(GameState gameState);
        void InterChangeState(GameState stateOne, GameState stateTwo);

        int GetGamesPlayed();
        string GetNextScene();
        string GetLastScene();
        float GetMapSize();
        int GetGamesFrame();
        GameState GetCurrentState();
        GameState GetLastState();
        DefaultScriptableObject GetDefaultScriptable();
    }
}