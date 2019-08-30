using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    public class TankView : MonoBehaviour
    {
        private TankController controller;
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void SetController(TankController _controller)
        {
            controller = _controller;
        }

        public TankController GetController()
        {
            return controller;
        }
    }
}
