using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// this class instantiates the tank model in game
    /// </summary>
    public class TankController
    {
        public TankController(TankModel tankModel, TankView tankPrefab)
        {
            TankModel = tankModel;
            TankView = GameObject.Instantiate<TankView>(tankPrefab);
            Debug.Log("tank prefab instantiated");
        }

        public TankModel TankModel { get; }
        public TankView TankView { get; }
    }
}