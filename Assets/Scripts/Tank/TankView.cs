using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    public class TankView : MonoBehaviour
    {
        private TankController controller;

        public void SetController(TankController _controller)
        {
            controller = _controller;
        }

        public TankController GetController()
        {
            return controller;
        }

        public void DestroyTankView()
        {
            Destroy(gameObject);
        }
    }
}
