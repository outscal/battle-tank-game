using UnityEngine;

namespace Scriptable_Object.Tank
{
    [CreateAssetMenu(fileName = "NewTankList", menuName = "User/Tank/TankList", order = 0)]
    public class TankList : ScriptableObject
    {
        [SerializeField] private Tank[] tanks;
        public Tank[] List => tanks;
    }
}