using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    public class TankController
    {
        private TankModel tankModel;
        private TankView tankView;
        public TankController(TankView _tankPrefab)
        {
            tankModel = new TankModel();
            tankView = GameObject.Instantiate<TankView>(_tankPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
