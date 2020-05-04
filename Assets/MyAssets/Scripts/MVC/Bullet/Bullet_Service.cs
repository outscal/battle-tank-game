using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Controller;
using Bullet.Model;
using Bullet.View;
using System;
using ScriptableObj;

namespace Bullet.Service
{
    public class Bullet_Service : MonoSingletonGeneric<Bullet_Service>
    {
        //public BulletView bulletView;

        private List<BulletController> bullets = new List<BulletController>();
        public void CreateBullet(Vector3 position, Quaternion rotation, BulletScriptableObject type)
        {
            
            BulletScriptableObject bullet = type;
            Debug.Log("till this line all fine");
            BulletModel bulletModel = new BulletModel(bullet);
            Debug.Log("this debug is not showing");
            BulletController bulletController = new BulletController(bulletModel, bullet.BulletView, position, rotation);
            bullets.Add(bulletController);
        }
        void Start()
        {
            //BulletModel b_Model = new BulletModel(10f);
            //BulletController b_Controller = new BulletController(b_Model, bulletView);
        }
    }
}