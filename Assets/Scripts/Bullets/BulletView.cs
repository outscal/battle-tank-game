using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletView : MonoBehaviour
    {

        private Rigidbody rb;

        [HideInInspector]
        public BulletController bulletController;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Enemy.EnemyView>() != null)
            {
                bulletController.DamageEnemy(collision.gameObject.GetComponent<Enemy.EnemyView>());
            }

            if (collision.gameObject.GetComponent<Bullet.BulletView>() == null)
                DestroyBullet();
        }

        public void MoveBullet(Vector3 direction, float force, float destroyTime)
        {
            rb.AddForce(direction * force, ForceMode.Impulse);
            StartCoroutine(DestroyBullet(destroyTime));
        }

        public void DestroyBullet()
        {
            bulletController.DestroyController();
            Destroy(gameObject);
        }

        IEnumerator DestroyBullet(float destroyTime)
        {
            yield return new WaitForSeconds(destroyTime);
            DestroyBullet();
        }

    }
}