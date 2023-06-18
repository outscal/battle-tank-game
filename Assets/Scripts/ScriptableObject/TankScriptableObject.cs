using UnityEngine;

namespace BattleTank.PlayerTank
{
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/CreateNewTankScriptableObject")]
    public class TankScriptableObject : ScriptableObject
    {
        public TankType TankType;
        public string TankName;
        public int MovementSpeed;
        public float RotationSpeed;
        public int Health;
        public TankView TankView;
        public GameObject AimPoint;
    }
}