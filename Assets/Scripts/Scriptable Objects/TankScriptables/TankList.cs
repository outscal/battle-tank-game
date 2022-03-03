using UnityEngine;

namespace TankScriptables
{
    [CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObject/Tank/TankScriptableObjectList")]
    public class TankList : ScriptableObject
    {
        public TankScriptableObject[] tanks;
    }
}