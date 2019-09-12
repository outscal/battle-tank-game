using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    public class TankView : MonoBehaviour, IDamageable
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

        public bool TakeDamage(int _damage, TankController _sourceTank)
        {
            if (controller != null)
            {
                return controller.ApplyDamage(_damage, _sourceTank);
            }
            return false;
        }
    }
}
