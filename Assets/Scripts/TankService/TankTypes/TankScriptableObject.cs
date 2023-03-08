using TankBattle.Tank.View;
using UnityEngine;

namespace TankBattle.Tank.TankTypes
{
    [CreateAssetMenu(fileName ="TankScriptableObject", menuName ="ScriptableObjects/NewTank")]
    public class TankScriptableObject : ScriptableObject
    {
        public TankView tankView;
        public TankType tankType;
        public string tankName;
        public float speed;
        public float rotateSpeed;
        public float jumpValue;
    }
}
