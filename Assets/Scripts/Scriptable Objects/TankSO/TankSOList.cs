using UnityEngine;

namespace TankSO
{
    [CreateAssetMenu(fileName = "TankSOList", menuName = "ScriptableObject/Tank/TankScriptableObjectList")]
    public class TankSOList : ScriptableObject
    {
        public TankScriptableObject[] tanks;
    }
}