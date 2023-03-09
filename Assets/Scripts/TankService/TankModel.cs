using UnityEngine;

namespace TankBattle.Tank.Model
{
    public class TankModel
    {
        public TankModel(TankTypes.TankScriptableObject tankScriptableObject)
        {
            TankTypes = tankScriptableObject.tankType;
            Speed = tankScriptableObject.speed;
            RotateSpeed = tankScriptableObject.rotateSpeed;
            JumpForce = tankScriptableObject.jumpValue;
            GetHealth = tankScriptableObject.health;
            GetColor = tankScriptableObject.tankColor;
        }

        // read-only properties
        public TankType TankTypes { get; }
        public float Speed { get; }
        public float RotateSpeed { get; }
        public float JumpForce { get; }
        public float GetHealth { get; }
        public Color GetColor { get; }
    }
}