using UnityEngine;

namespace TankBattle.Tank
{
    public class TankModel
    {
        // read-only properties
        public TankType TankTypes { get; }
        public float Speed { get; }
        public float RotateSpeed { get; }
        public float JumpForce { get; }
        public float GetSetHealth { get; set; }
        public Color GetColor { get; }
        public float minLaunchForce { get; }
        public float maxLaunchForce { get; }
        public float maxChargeTime { get; }

        public TankModel(TankTypes.TankScriptableObject tankScriptableObject)
        {
            TankTypes = tankScriptableObject.tankType;
            Speed = tankScriptableObject.speed;
            RotateSpeed = tankScriptableObject.rotateSpeed;
            JumpForce = tankScriptableObject.jumpValue;
            GetSetHealth = tankScriptableObject.health;
            GetColor = tankScriptableObject.tankColor;
            minLaunchForce = tankScriptableObject.minLaunchForce;
            maxLaunchForce = tankScriptableObject.maxLaunchForce;
            maxChargeTime = tankScriptableObject.maxChargeTime;
        }
    }
}