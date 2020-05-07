using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Service;
using Bullet.Controller;
using Bullet.Model;

namespace Bullet.View
{
    //public TankType tankType;
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController;
        void Start()
        {
            Debug.Log("Bullet view created");
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            bulletController.Movement();
        }

        public void SetBulletController(BulletController b_Controller)
        {
            bulletController = b_Controller;
        }

        //public BulletController  bulletController{ get; }
    }
}