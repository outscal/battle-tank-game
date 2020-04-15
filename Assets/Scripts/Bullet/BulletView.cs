using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Enemy;
using TankGame.Tank;

namespace TankGame.Bullet
{

    public class BulletView : MonoBehaviour
    {
        private int bulletSpeed;
        private float bulletDamage;
        public Rigidbody rb;
        public ParticleSystem bombExplosion;
        //private Vector3 spawnerPOS;
        private float damage;
        private BulletController controller;
       

        private void Start()
        {
            //setSpeed();
        }

        public void SetBulletDetails(BulletModel model, float healthDamage)
        {
            bulletSpeed = model.Speed;
            //bulletDamage = model.Damage;
            //spawnerPOS = spawnerPos;
            damage = healthDamage;
        }

        public void InitializeController(BulletController bulletController)
        {
             controller = bulletController;
        }

        public BulletController GetController()
        {
            return controller;
        }

        private void setSpeed()
        {
            //rb.velocity = new Vector3(0, 0, spawnerPOS.z) * bulletSpeed;

        }

        private void OnCollisionEnter(Collision collision)
        {
            //CheckCollision collisionCheck = new CheckCollision(collision, damage);

            //Instantiate(bombExplosion, transform.position, transform.rotation);
            Collider[] colliders = Physics.OverlapSphere(collision.transform.position, 2f);
            foreach (Collider hit in colliders)
            {
                if (hit.GetComponent<EnemyView>())
                {
                    EnemyView enemy = hit.GetComponent<EnemyView>();
                    if (enemy != null)
                    {
                        controller.ApplyEnemyDamage(damage, enemy);
                    }
                }
                else
                {
                    if (hit.GetComponent<TankView>())
                    {
                        TankView tank = hit.GetComponent<TankView>();
                        if (tank != null)
                        {
                            Debug.Log("player is hit");
                            controller.ApplyPlayerDamage(damage, tank);
                        }
                    }
                }
                controller.DestroyBulletView(this);
            }

        }

       
    }
}
