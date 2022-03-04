using UnityEngine;

namespace Scriptable_Object.Tank
{
    public abstract class TankList : ScriptableObject
    {
        virtual public Tank[] List => null;
    }
}