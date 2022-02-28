using UnityEngine;

namespace Scriptable_Object.Tank
{
    //[CreateAssetMenu(fileName = "NewTankList", menuName = "User/Tank/TankList", order = 0)]
    public abstract class TankList : ScriptableObject
    {
        virtual public Tank[] List => null;
    }
}