using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.MVC.Tank
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletView : MonoBehaviour
    {
        private BulletController bulletController;
        public void SetBulletController(BulletController controller)
        {
            bulletController = controller;
        }

        public void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}