using BulletServices;
using PlayerTankServices;
using UnityEngine;

namespace TankScriptables
{
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/Tank")]
    public class TankScriptableObject : ScriptableObject
    {
        public TankType tankType;
        public Color tankColor;
        public int health;
        public float movementSpeed;
        public float rotationSpeed;
        public float tankHeadRotation;
        public BulletType bulletType;
        public float minLaunchForce;
        public float maxLaunchForce;
        public float maxChargeTime;
    }
}

