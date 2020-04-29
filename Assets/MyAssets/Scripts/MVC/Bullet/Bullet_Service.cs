using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Controller;
using Bullet.Model;
using Bullet.View;

namespace Bullet.Service
{
    public class Bullet_Service : MonoSingletonGeneric<Bullet_Service>
    {
        public BulletView bulletView;

        void Start()
        {
            BulletModel b_Model = new BulletModel(10f);
            BulletController b_Controller = new BulletController(b_Model, bulletView);
        }
    }
}