using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankBattle.Bullet;

namespace TankBattle.Tank
{
    public class TankController
    {
        private TankModel tankModel;
        private TankView tankView;
        private BulletService bulletService;
        public TankController(TankView _tankPrefab)
        {
            tankModel = new TankModel();
            tankView = GameObject.Instantiate<TankView>(_tankPrefab, Vector3.zero, Quaternion.identity);
            bulletService = GameObject.FindObjectOfType<BulletService>();
        }

        public void FireBullet()
        {
            bulletService.TriggerBullet(tankView.transform.position, tankView.transform.rotation);
        }
    }
}
