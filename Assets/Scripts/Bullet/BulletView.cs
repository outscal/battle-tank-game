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
        private BulletModel model;
        private BulletType bulletType;
               

        private void Start()
        {
            //setSpeed();
        }

        public void SetBulletDetails( float healthDamage)
        {
            model = controller.BulletModel;
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

        public void Destroy()
        {
            ParticleService.Instance.CreateBulletExplosion(this.transform.position, this.transform.rotation);
            Destroy(gameObject, 0.1f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            //CheckCollision collisionCheck = new CheckCollision(collision, damage);

            //Instantiate(bombExplosion, transform.position, transform.rotation);
            Collider[] colliders = Physics.OverlapSphere(collision.transform.position, 0.1f);
            controller.DestroyBulletView();
            foreach (Collider hit in colliders)
            {

                IDamagable damagable = hit.gameObject.GetComponent<IDamagable>();
                if(damagable != null){
                    damagable.TakeDamage(damage);
                }


                //if (hit.GetComponent<EnemyView>())
                //{
                //    EnemyView enemy = hit.GetComponent<EnemyView>();
                //    if (enemy != null)
                //    {
                //        controller.ApplyEnemyDamage(damage, enemy);
                //    }
                //}
                
            }

        }

       
    }
}
