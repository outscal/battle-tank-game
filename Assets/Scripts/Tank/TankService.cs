using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Tank
{
    public interface ITankService 
    {
        public TankController CreateTank(Scriptable_Object.Tank.Tank tank);

        public void Destroy(TankController controller);
    }
}
