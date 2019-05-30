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
using Interfaces;

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

        private IAchievement achievementManager;
        private IGameManager gameManager;

        public int timeScaleMultiplier { get; private set; }

        private void OnDisable()
        {
            if (PlayerManager.Instance != null)
            {
                PlayerManager.Instance.playerDataEvent -= GetPlayerEvents;
            }
            //if (AchievementM.AchievementManager.Instance != null)
                //AchievementM.AchievementManager.Instance.AchievementUnlocked -= DisplayAchievement;
        }

        private void OnEnable()
        {
            PlayerManager.Instance.playerDataEvent += GetPlayerEvents;
        }

        private void Start()
        {
            if (achievementManager == null)
                achievementManager = StartService.Instance.GetService<IAchievement>();

            if (gameManager == null)
                gameManager = StartService.Instance.GetService<IGameManager>();

            achievementManager.AchievementUnlocked += DisplayAchievement;

            playerUIs = new List<PlayerUI>();
            miniMapCameras = new List<MiniMapCamera>();
            playerCameras = new List<Camera>();

            exitReplayBtn.onClick.AddListener(() => ExitReplay());
            speedUpReplayBtn.onClick.AddListener(() => SpeedUp());
            speedDownReplayBtn.onClick.AddListener(() => SpeedDown());

            if (gameManager.GetCurrentState().gameStateType == GameStateType.Game)
            {
                gameMenuHolder.SetActive(true);
                replayMenu.SetActive(false);
            }
            else if (gameManager.GetCurrentState().gameStateType == GameStateType.Replay)
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
            mapCamera.SetMiniMaptarget(view.transform);
            mapCamera.GetComponent<Camera>().targetTexture = Resources.Load("MinimapTex" + (playerID + 1)) as RenderTexture;
            //Debug.Log("MinimapTex" + (playerID + 1));

            playerUI.SetMiniMap(mapCamera.GetComponent<Camera>());

            playerCameras.Add(view.PlayerCam);

            playerCameras[playerID].rect = new Rect((1f / playerCount) * playerID, 0, 1f / playerCount, 1);
            //Debug.Log("[GameUI] PlayerID:" + playerID);
        }

        void ExitReplay()
        {
            gameManager.OnGameOver();
            gameManager.UpdateGameState(new GameOverState());
            SceneManager.LoadScene(gameManager.GetDefaultScriptable().gameOverScene);
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

        void GetPlayerEvents(PlayerData playerData)
        {
            UIManager.Instance.playerScore = playerData.playerScore;
            playerUIs[playerData.playerID].setScore(playerData.playerScore);

            if (UIManager.Instance.playerScore > UIManager.Instance.hiScore)
                UIManager.Instance.SetHiScore(UIManager.Instance.playerScore);

            UIManager.Instance.InvokeScoreIncreasedAction(playerData.playerID);
            //Debug.Log("[GameUI] Score UpdatedPlayerID:" + playerData.playerID);

            playerUIs[playerData.playerID].setHealth((int)playerData.playerHealth);
            //playerHealthText.text = "Player Health:" + value;
            //Debug.Log("[GameUI] Health Updated PlayerID:" + playerData.playerID);
        }

        public void GameOver()
        {
            StartCoroutine(GameOverCoroutine());
        }

        private IEnumerator GameOverCoroutine()
        {
            yield return new WaitForSeconds(1f);
            gameManager.UpdateGameState(new GameReplayState(gameManager.GetDefaultScriptable().gameScene));
            SceneManager.LoadScene(gameManager.GetDefaultScriptable().gameScene);
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