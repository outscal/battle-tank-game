using UnityEngine;

namespace BattleTank.TankSO
{
    [CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/TankList")]
    public class TankScriptableObjectList : ScriptableObject
    {
        public TankScriptableObject[] Tanks;
    }
}