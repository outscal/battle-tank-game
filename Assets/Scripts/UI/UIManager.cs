using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using BTScriptableObject;

namespace UI
{
    public enum GameState { MainMenu, Game, GameOver }

    public class UIManager : Singleton<UIManager>
    {

        [SerializeField] private DefaultScriptableObject defaultScriptableObject;

        public DefaultScriptableObject DefaultScriptableObject { get { return defaultScriptableObject; }}

        private GameState gameState = GameState.MainMenu;

        public GameState GameState { get { return gameState; } }

        public int playerScore = 0;

        public int hiScore { get; private set; }

        public void SetHiScore(int value)
        {
            hiScore = value;
            PlayerPrefs.SetInt("HiScore", hiScore);
        }

        public void Start()
        {
            if (PlayerPrefs.HasKey("HiScore"))
                hiScore = PlayerPrefs.GetInt("HiScore");
            else
                hiScore = 0;

        }

        public void UpdateGameState(GameState gameState)
        {
            this.gameState = gameState;
        } 
    }
}