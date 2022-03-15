using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ObserverPattern
{
   public class AchievementManager : GenericSingleton<AchievementManager> 
   {
        public AchievementModel model;
        public AchievementData[] data;
        
        public AchievementTypes types;

        public Animator anim;
        public GameObject achNotify;
        public Text[] details;

        public bool isActivated = false;
        private void Start()
        {
            PlayerPrefs.DeleteKey("Achievement");
            LoadPrefs();
        }

        public void SavePrefs()
        {
            PlayerPrefs.SetInt("Achievement", TankController.Instance.bulletCount);           
            PlayerPrefs.Save();
        }
        private void LoadPrefs()
        {
            var bullets = PlayerPrefs.GetInt("Achievement", 0);
            TankController.Instance.bulletCount = bullets;
        }
        private void OnApplicationQuit()
        {
            SavePrefs();
        }

        private void Update()
        {
            ActivatingUI();
        }

        public void DisplayAchievements()
        {
            if(TankController.Instance.type == AchievementTypes.AmateurShooter) 
            {
                types = AchievementTypes.AmateurShooter;
                AchievementData Data = data[0];
                model = new AchievementModel(Data);
                details[0].text = "ACHIEVEMENT : " + model.TitleText;
                details[1].text = model.DescriptionText;
                isActivated = true;
            }
            if(TankController.Instance.type == AchievementTypes.SharpShooter)
            {
                types = AchievementTypes.SharpShooter;
                AchievementData Data = data[1];
                model = new AchievementModel(Data);
                details[0].text = "ACHIEVEMENT : " + model.TitleText;
                details[1].text = model.DescriptionText;
                isActivated = true;
            }
            if (TankController.Instance.type == AchievementTypes.DeadShooter)
            {
                types = AchievementTypes.DeadShooter;
                AchievementData Data = data[2];
                model = new AchievementModel(Data);
                details[0].text = "ACHIEVEMENT : " + model.TitleText;
                details[1].text = model.DescriptionText;
                isActivated = true;
            }
            PlayerPrefs.Save();
        }
        private void ActivatingUI()
        {
          if (isActivated)
          {
             achNotify.gameObject.SetActive(true);
             anim.SetBool("Activate", true);
             StartCoroutine(DisableUI());
          }
        }

        IEnumerator DisableUI()
        {
            isActivated = false;
            TankController.Instance.Shoot -= DisplayAchievements;
            yield return new WaitForSeconds(3.5f);
            achNotify.gameObject.SetActive(false);
            anim.SetBool("Activate", false); 
        }
    }


}
