using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MVC.Tank
{
    public class BulletController
    {
        public BulletModel BulletModel { get; }
        public BulletView BulletView { get; }
        private BulletScriptableObject[] bulletConfiguration;
        public BulletController(BulletModel bulletModel, BulletView bulletPrefab)
        {

            BulletModel = bulletModel;
            BulletView = GameObject.Instantiate(BulletView);
            BulletView.SetBulletController(this);
            BulletView.GetComponent<Rigidbody>().velocity = new Vector3(3,3,3); //Might need to add more params

          
        }


        public void onCollisionEnter(Collider other)
        {
            IDamagable damagable = other.GetComponent<IDamagable>();

            if(damagable != null)
            {
                
            }

            BulletView.DestroyBullet();
        }

        private void ApplyDamage(IDamagable damagable, Collider other)
        {
            Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();

            if (targetRigidbody)
            {
                damagable.TakeDamage(BulletModel.bulletDamage);
            }
        }

        public Vector3 RandomSpawnLocation()
        {
            float spawnXRange = Random.Range(-14, 15);
            float spawnZRange = Random.Range(-15, 17);
            float Y = 0;

            return new Vector3(spawnXRange, Y, spawnZRange);

        }

        int damage = 25;
        private void OnCollisionEnter(Collision collision)
        {
            IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
            if(damagable != null)
            {
                damagable.TakeDamage(damage);
            }
        }
      
    }
}