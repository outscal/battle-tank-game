using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Bullet;
using TankGame.Event;

namespace TankGame.Tank
{
    public class TankController
    {
        public TankController(TankModel tankModel, TankView tankPrefab, Transform spawner)
        {
            TankModel = tankModel;
            TankView = GameObject.Instantiate<TankView>(tankPrefab, spawner.transform.position, spawner.transform.rotation);
            TankView.InitialiseController(this);
            TankView.SetViewDetails();
        }

        public void PlaySound(PlayerSfx sfxIndex, bool isLoop)
        {
            SoundManager.Instance.playPlayerSound(sfxIndex, false);
        }

        public void fire(Transform bulletSpawn, float bulletDamange)
        {
            BulletService.Instance.spawnBullet(bulletSpawn, bulletDamange);
            PlaySound(PlayerSfx.Fire, false);
        }

        public void ApplyDamage(float damage)
        {
            if (TankModel != null)
            {
                if ((TankModel.Health - damage) <= 0)
                {
                    DestroyView();
                }
                else
                {
                    TankModel.Health -= damage;
                    Debug.Log(TankModel.Health);
                    TankView.SetTankHealth(TankModel.Health);
                }
            }
            return;
        }

        public void DestroyView()
        {
            TankService.Instance.DestroyTank(this);
        }
        public void Destroy()
        {
            if (TankView != null && TankModel != null)
            {
                TankView.Destroy();
                TankModel = null;
            }
            return;
        }

        public TankView GetTankView()
        {
            return TankView.GetView();
        }

        public TankModel TankModel { get; set; }
        public TankView TankView { get; }
    }
}
