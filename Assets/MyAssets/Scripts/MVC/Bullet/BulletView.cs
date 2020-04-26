using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Service;
using Bullet.Controller;
using Bullet.Model;

namespace Bullet.View
{
    public class BulletView : MonoBehaviour
    {
        private BulletController bulletController;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void setController(BulletController b_Controller)
        {
            bulletController = b_Controller;
        }
    }
}