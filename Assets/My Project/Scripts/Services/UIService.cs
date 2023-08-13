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
      
        private BulletController bulletController;
        public float GetJoystickHorizontal() => joystick.Horizontal;
        public float GetJoystickVertical() => joystick.Vertical;
        private int bullet_count;
        public void ShootBullet()
        {
            bullet_count++;
            // BulletService.Instance.onBulletFired?.Invoke(bullet_count);
            BulletService.Instance.BulletShootByTank(TankService.Instance.GetbulletTransform());
        }
    }
}
