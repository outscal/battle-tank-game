using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankBattle.Tank;

namespace TankBattle.Bullet
{
    public class BulletView : MonoBehaviour
    {
        private BulletController controller;

        public void SetController(BulletController _controller)
        {
            controller = _controller;
        }


        private void OnTriggerExit(Collider collider) 
        {
            if (collider.gameObject.tag == "GameBoundary")
            {
                if (controller != null)
                {
                    controller.DestroyBullet();
                }
            }
        }


        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Tank")
            {
                TankController colliderTank = collision.gameObject.GetComponent<TankView>().GetController();
                if(colliderTank != controller.sourceTank)
                {
                    colliderTank.ApplyDamage(controller.GetBulletDamagePower());
                    
                    if (controller != null)
                    {
                        controller.DestroyBullet();
                    }
                }
            }
        }
            
    }
}
