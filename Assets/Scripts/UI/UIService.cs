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
        public Text enemyKillAchievmentText;
        public Text bulletAchievmentText;
        protected override void Awake()
        {
            base.Awake();
        }
        protected override void Start()
        {
            base.Start();

            EventService.Instance.EnemyDeath += SetPLayerKillsUI;
            EventService.Instance.EnemyKillAchievment += ShowAchievmentUnlock;
            EventService.Instance.BulletAchievment += ShowBulletFired;
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

        private void SetPLayerKillsUI(int killCount)
        {
            playerKills.text = "Kills: " + killCount;
        }

        async void ShowAchievmentUnlock(int deathCount)
        {
            enemyKillAchievmentText.gameObject.SetActive(true);
            enemyKillAchievmentText.text = "Congracts! " + deathCount + "Kills, New Achievment Unlocked.";
            await new WaitForSeconds(2f);
            enemyKillAchievmentText.gameObject.SetActive(false);
        }


        async void ShowBulletFired(int bulletCount)
        {
            bulletAchievmentText.gameObject.SetActive(true);
            bulletAchievmentText.text = "Amazing! " + bulletCount + "Bullets Are Fired";
            await new WaitForSeconds(2f);
            bulletAchievmentText.gameObject.SetActive(false);
        }


        async void CallIntroTexts()
        {
            introTexts[0].gameObject.SetActive(true);
            await new WaitForSeconds(1.0f);
            introTexts[0].gameObject.SetActive(false);
            introTexts[1].gameObject.SetActive(true);
            await new WaitForSeconds(1.0f);
            introTexts[1].gameObject.SetActive(false);
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