using UnityEngine;
using ScriptableObj;

namespace Tank
{

    public class TankModel
    {
        public TankModel(TankScriptableObj tankScriptableObj)
        {
            TankTypes = tankScriptableObj.TankTypes;
            Speed = tankScriptableObj.TankSpeed;
            Health = tankScriptableObj.Health;
            TankDamageBooster = tankScriptableObj.TankDamageBooster;
            TurnSpeed = tankScriptableObj.TurnSpeed;
            PlayerNumber = tankScriptableObj.PlayerNumber;
            PitchRange = tankScriptableObj.PitchRange;
            BulletLaunchForce = tankScriptableObj.BulletLaunchForce;
            FireKey = tankScriptableObj.FireKey;
            TankView = tankScriptableObj.TankView;
            SpawnPoint = tankScriptableObj.TankSpawnPoint;
         }

        public TankTypes TankTypes;
        public int Speed { get; }
        public float Health { get; }
        public float TankDamageBooster { get; }
        public int PlayerNumber { get; }
        public float PitchRange { get; }
        public float BulletLaunchForce { get; }
        public KeyCode FireKey { get; }
        public float TurnSpeed { get; }
        public TankView TankView { get; }
        public Transform SpawnPoint { get; }
    }
}
