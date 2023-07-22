using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace BattleTank
{
    public class UIService : GenericSingleTon<UIService>
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private GameObject canvas;

        [SerializeField] private TextMeshProUGUI Text;

        private BulletController bulletController;
        public float GetJoystickHorizontal() => joystick.Horizontal;
        public float GetJoystickVertical() => joystick.Vertical;
        private int bullet_count;
        private void Start()
        {
            canvas.SetActive(false);
        }
        public void ShootBullet()
        {
            bullet_count++;
            // BulletService.Instance.onBulletFired?.Invoke(bullet_count);
            BulletService.Instance.BulletShootByTank(TankService.Instance.GetbulletTransform());
        }

        public void ShowAchievement(string achHeading, string achSubText)
        {
            if (AchievementSystem.Instance.Achieved != null)
            {
                canvas.SetActive(true);
                Text.text = achHeading + achSubText;
            }
               
        }
    }
}
