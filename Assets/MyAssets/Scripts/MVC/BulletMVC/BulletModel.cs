using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class BulletModel
    {
        private BulletController bulletController;
        public BulletModel(BulletScriptableObjects bullet)
        {

        }

        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }
    }
}