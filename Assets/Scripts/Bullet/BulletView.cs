using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Enemy;

namespace TankGame.Bullet
{

    public class BulletView : MonoBehaviour
    {
        private int bulletSpeed;
        private float bulletDamage;
        public Rigidbody rb;
        public ParticleSystem bombExplosion;
        private Vector3 spawnerPOS;
        private float damage;
        private BulletController controller;

        private void Start()
        {
            //setSpeed();
        }

        public void SetBulletDetails(BulletModel model, float healthDamage)
        {
            bulletSpeed = model.Speed;
            bulletDamage = model.Damage;
            //spawnerPOS = spawnerPos;
            damage = healthDamage;
        }

        public void InitializeController(BulletController bulletController)
        {
             controller = bulletController;
        }

        private void setSpeed()
        {
            rb.velocity = new Vector3(0, 0, spawnerPOS.z) * bulletSpeed;

        }

        private void OnCollisionEnter(Collision collision)
        {
            //Instantiate(bombExplosion, transform.position, transform.rotation);
            bombExplosion.Play();
            Collider[] colliders = Physics.OverlapSphere(collision.transform.position, 5f);
            foreach (Collider hit in colliders)
            {
                EnemyView enemy = hit.GetComponent<EnemyView>();
                if (enemy != null)
                {
                    enemy.ApplyDamage(damage);
                }
                   
                    
            }
            StartCoroutine(destroy());
        }

        IEnumerator destroy()
        {
            yield return new WaitForSeconds(0.2f);
            Destroy(gameObject);

        }
    }
}
