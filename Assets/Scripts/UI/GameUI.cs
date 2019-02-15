using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;
using UnityEngine.SceneManagement;
using Manager;
using System;
using StateMachine;
using Player;
using TMPro;
using CameraScripts;

namespace UI
{
    public class GameUI : Instance<GameUI>
    {

        [SerializeField] private Text achievementText;
        [SerializeField] private GameObject gameMenuHolder, replayMenu;
        [SerializeField] private Button exitReplayBtn, speedUpReplayBtn, speedDownReplayBtn;
        [SerializeField] private PlayerUI playerUIPrefab;
        [SerializeField] private MiniMapCamera miniMapCameraPrefab;

        private List<PlayerUI> playerUIs;
        private List<MiniMapCamera> miniMapCameras;
        private List<Camera> playerCameras;

        //[SerializeField] private Camera camera

        public int timeScaleMultiplier { get; private set; }

        //public event Action ScoreIncreased;

        private void OnDisable()
        {
            if (PlayerManager.Instance != null)
            {
                PlayerManager.Instance.playerSpawned -= GetPlayerEvents;
            }
            if (AchievementM.AchievementManager.Instance != null)
                AchievementM.AchievementManager.Instance.AchievementUnlocked -= DisplayAchievement;
        }

        private void OnEnable()
        {
            PlayerManager.Instance.playerSpawned += GetPlayerEvents;
            AchievementM.AchievementManager.Instance.AchievementUnlocked += DisplayAchievement;
        }

        private void Start()
        {
            playerUIs = new List<PlayerUI>();
            miniMapCameras = new List<MiniMapCamera>();
            playerCameras = new List<Camera>();

            exitReplayBtn.onClick.AddListener(() => ExitReplay());
            speedUpReplayBtn.onClick.AddListener(() => SpeedUp());
            speedDownReplayBtn.onClick.AddListener(() => SpeedDown());

            if (GameManager.Instance.currentState.gameStateType == GameStateType.Game)
            {
                gameMenuHolder.SetActive(true);
                replayMenu.SetActive(false);
            }
            else if (GameManager.Instance.currentState.gameStateType == GameStateType.Replay)
            {
                gameMenuHolder.SetActive(false);
                replayMenu.SetActive(true);
            }
        }

        public void SetUpUI(int playerCount, int playerID, PlayerView view)
        {
            PlayerUI playerUI = Instantiate(playerUIPrefab);
            playerUI.gameObject.transform.SetParent(gameMenuHolder.transform);
            playerUIs.Add(playerUI);

            MiniMapCamera mapCamera = Instantiate(miniMapCameraPrefab);
            miniMapCameras.Add(mapCamera);
            mapCamera.SetMiniMaptarget(view.gameObject);

            playerCameras.Add(view.PlayerCam);

            playerCameras[playerID].rect = new Rect(0.5f * playerID, 0, 0.5f * (1 + playerID), 1);
            Debug.Log("[GameUI] PlayerID:" + playerID);
        }


        void ExitReplay()
        {
            GameManager.Instance.UpdateGameState(new GameOverState());
            SceneManager.LoadScene(GameManager.Instance.DefaultScriptableObject.gameOverScene);
        }

        void SpeedUp()
        {
            if (timeScaleMultiplier < 4)
            {
                timeScaleMultiplier++;
                Time.timeScale = timeScaleMultiplier;
            }
        }

        void SpeedDown()
        {
            if (timeScaleMultiplier > 1)
            {
                timeScaleMultiplier--;
                Time.timeScale = timeScaleMultiplier;
            }
        }

        void GetPlayerEvents(int playerID)
        {
            if (PlayerManager.Instance.playerControllerList == null)
                Debug.Log("[GameUI] PlayerController is missing");
            else if (PlayerManager.Instance.playerControllerList != null)
                Debug.Log("[GameUI] PlayerController is present");

            PlayerManager.Instance.playerControllerList[playerID].scoreUpdate += UpdatePlayerScore;
            PlayerManager.Instance.playerControllerList[playerID].healthUpdate += UpdatePlayerHealth;
            Debug.Log("[GameUI] Player Events Called");
        }

        void UpdatePlayerScore(int value, int playerID)
        {
            UIManager.Instance.playerScore = value;
            playerUIs[playerID].setScore(value);
            //playerScoreText.text = "Player Score:" + UIManager.Instance.playerScore;
            if (UIManager.Instance.playerScore > UIManager.Instance.hiScore)
                UIManager.Instance.SetHiScore(UIManager.Instance.playerScore);

            //ScoreIncreased?.Invoke();
            UIManager.Instance.InvokeScoreIncreasedAction(playerID);
            Debug.Log("[GameUI] Score Updated");
        }

        void UpdatePlayerHealth(int value, int playerID)
        {
            playerUIs[playerID].setHealth(value);
            //playerHealthText.text = "Player Health:" + value;
            Debug.Log("[GameUI] Health Updated");
        }

        public void PlayerDestroyed(int playerID)
        {
            PlayerManager.Instance.playerControllerList[playerID].scoreUpdate -= UpdatePlayerScore;
            PlayerManager.Instance.playerControllerList[playerID].healthUpdate -= UpdatePlayerHealth;
        }

        public void GameOver()
        {
            //PlayerManager.Instance.playerControllerList[playerID].scoreUpdate -= UpdatePlayerScore;
            //PlayerManager.Instance.playerControllerList[playerID].healthUpdate -= UpdatePlayerHealth;

            StartCoroutine(GameOverCoroutine());
        }

        //public void Respawn(Inputs.InputComponent inputComponent)
        //{
        //    Inputs.InputManager.Instance.RemoveInputComponent(inputComponent);
        //    PlayerManager.Instance.SpawnPlayer();
        //}

        private IEnumerator GameOverCoroutine()
        {
            yield return new WaitForSeconds(1f);
            //GameManager.Instance.UpdateGameState(new GameOverState());
            GameManager.Instance.UpdateGameState(new GameReplayState(GameManager.Instance.DefaultScriptableObject.gameScene));
            SceneManager.LoadScene(GameManager.Instance.DefaultScriptableObject.gameScene);
        }  

        private void DisplayAchievement(string value)
        {
            achievementText.text = value;
            StartCoroutine(AchievementCoroutine());
        }

        IEnumerator AchievementCoroutine()
        {
            achievementText.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            achievementText.gameObject.SetActive(false);
        }

    }
}