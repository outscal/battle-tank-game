using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TankGame.Spawner;
using TankGame.Event;
using System;

namespace TankGame.UI
{
    public class UIService : MonoSingletonGeneric<UIService>
    {
        public Button[] buttons;
        public Text[] introTexts;
        public Text playerKills;
        public Text bulletFired;
        public Text enemyKillAchievmentText;
        public Text bulletAchievmentText;

        private int FiredBullets;
        private int KilledEnemies;
        protected override void Awake()
        {
            base.Awake();
        }
        protected override void Start()
        {
            base.Start();


            //EventService.Instance.EnemyDeath += ShowEnemyKilledUI;
            EventService.Instance.EnemyKillAchievment += ShowAchievmentUnlock;
            EventService.Instance.BulletAchievment += ShowBulletAchievmentUnlock;
            //EventService.Instance.BulletFired += ShowBulletFiredUI;
            //for (int i = 0; i < buttons.Length; i++)
            //{
            //    int buttonIndex = i; //(important) for closure error, first capture the data
            //    buttons[buttonIndex].onClick.AddListener(() => generateTank(buttonIndex));
            //}
        }

        public void SetIntroText()
        {
            CallIntroTexts();
        }

        async void ShowAchievmentUnlock(int deathCount)
        {
            enemyKillAchievmentText.gameObject.SetActive(true);
            enemyKillAchievmentText.text = "Congrats! " + deathCount + "Kills, New Achievment Unlocked.";
            await new WaitForSeconds(2f);
            enemyKillAchievmentText.gameObject.SetActive(false);
        }
        async void ShowBulletAchievmentUnlock(int bulletCount)
        {
            bulletAchievmentText.gameObject.SetActive(true);
            bulletAchievmentText.text =  bulletCount + "bullets fired, New Achievment Unlocked.";
            await new WaitForSeconds(2f);
            bulletAchievmentText.gameObject.SetActive(false);
        }

        private void SetInGameUI()
        {
            ShowEnemyKilledUI();
            ShowBulletFiredUI();
        }

        public void ShowEnemyKilledUI()
        {
            KilledEnemies = PlayerPrefs.GetInt("KilledEnemies",0);
            playerKills.text = "Kills: " + KilledEnemies;
        }

        public void ShowBulletFiredUI()
        {
            FiredBullets = PlayerPrefs.GetInt("FiredBullets", 0);
            bulletFired.text = "Bullet Fired: " + FiredBullets;
        }


        async void CallIntroTexts()
        {
            introTexts[0].gameObject.SetActive(true);
            await new WaitForSeconds(1.0f);
            introTexts[0].gameObject.SetActive(false);
            introTexts[1].gameObject.SetActive(true);
            await new WaitForSeconds(1.0f);
            introTexts[1].gameObject.SetActive(false);
            SetInGameUI();
        }

        private void generateTank(int tankSerialNumber)
        {
            //SpawnerService.Instance.SpawnTanks(tankSerialNumber);  // passing button number for arrays of tank details
            SceneManager.LoadSceneAsync(1);
        }

        public void LoadGame()
        {
            SceneManager.LoadSceneAsync(1);
        }
    }
}