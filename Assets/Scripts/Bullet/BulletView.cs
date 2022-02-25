using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Bullet
{
    public class BulletView : MonoBehaviour
    {
        
        public BulletController BulletController { get; set; }
        private void FixedUpdate()
        {
            BulletController.Move();
        }

        private void OnCollisionEnter(Collision other)
        {
            BulletController.HitBy(other);
        }
    }
}