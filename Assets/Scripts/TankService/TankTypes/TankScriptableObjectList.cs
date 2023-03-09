using UnityEngine;

namespace TankBattle.Tank.TankTypes
{
    [CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/NewTankList")]
    public class TankScriptableObjectList : ScriptableObject
    {
        public TankScriptableObject[] tanks;
    }
}
