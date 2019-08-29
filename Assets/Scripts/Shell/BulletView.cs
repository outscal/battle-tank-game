using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankBattle.Tank;

namespace TankBattle.Bullet
{
    public class BulletView : MonoBehaviour
    {
        private BulletController controller = null;
        void Start()
        {
        
        }

        void Update()
        {
        
        }

        public void SetController(BulletController _controller)
        {
            controller = _controller;
        }

        void OnCollisionExit(Collision c)
        {
            if (c.collider.tag == "GameBoundary")
            {
                if (controller != null)
                {
                    controller.DestroyBullet();
                }
            }
        }

        void OnCollisionEnter(Collision c) 
        {
            if (c.collider.name == "Tank")
            {
                TankController _tankController = c.gameObject.GetComponent<TankController>();
                _tankController.ApplyDamage(controller.GetBulletDamagePower());
            }
            if (controller != null)
                {
                    controller.DestroyBullet();
                }
        }
    }
}
