using UnityEngine;

namespace Tank
{

    public class TankModel
    {

        public TankModel(TankScriptableObj tankScriptableObj)
        {
            Speed = tankScriptableObj.TankSpeed;
            Health = tankScriptableObj.Health;
            TankDamageBooster = tankScriptableObj.TankDamageBooster;
            M_TurnSpeed = tankScriptableObj.TurnSpeed;
            M_PlayerNumber = tankScriptableObj.PlayerNumber;
            M_PitchRange = tankScriptableObj.PitchRange;
            BulletLaunchForce = tankScriptableObj.BulletLaunchForce;
            FireKey = tankScriptableObj.FireKey;
            M_TankView = tankScriptableObj.tankView;
            M_SpawnPoint = tankScriptableObj.TankSpawnPoint;
         }

        public int Speed { get; }
        public float Health { get; }
        public float TankDamageBooster { get; }
        public int M_PlayerNumber { get; }
        public float M_PitchRange { get; }
        public float BulletLaunchForce { get; }
        public KeyCode FireKey { get; }
        public float M_TurnSpeed { get; }
        public TankView M_TankView { get; }
        public Transform M_SpawnPoint { get; }
    }
}
