using UnityEngine;

namespace TankSO
{
    [CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObject/Tank/TankScriptableObjectList")]
    public class TankSOList : ScriptableObject
    {
        public TankScriptableObject[] tanks;
    }
}