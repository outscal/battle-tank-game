using UnityEngine;

namespace Tank
{

    public class TankModel : IModel
    {
        public TankModel(TankScriptableObj tankScriptableObj)
        {
            M_TankTypes = tankScriptableObj.tankTypes;
            M_Speed = tankScriptableObj.TankSpeed;
            M_Health = tankScriptableObj.Health;
            M_TankDamageBooster = tankScriptableObj.TankDamageBooster;
            M_TurnSpeed = tankScriptableObj.TurnSpeed;
            M_PlayerNumber = tankScriptableObj.PlayerNumber;
            M_PitchRange = tankScriptableObj.PitchRange;
            M_BulletLaunchForce = tankScriptableObj.BulletLaunchForce;
            FireKey = tankScriptableObj.FireKey;
            M_TankView = tankScriptableObj.tankView;
            M_SpawnPoint = tankScriptableObj.TankSpawnPoint;
         }

        public TankTypes M_TankTypes;
        public int M_Speed { get; }
        public float M_Health { get; }
        public float M_TankDamageBooster { get; }
        public int M_PlayerNumber { get; }
        public float M_PitchRange { get; }
        public float M_BulletLaunchForce { get; }
        public KeyCode FireKey { get; }
        public float M_TurnSpeed { get; }
        public TankView M_TankView { get; }
        public Transform M_SpawnPoint { get; }
    }
}
