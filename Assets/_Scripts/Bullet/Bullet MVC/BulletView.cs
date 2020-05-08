using UnityEngine;
using Bullet.Controller;
using Idamagable;

namespace Bullet.View
{
    public class BulletView : MonoBehaviour
    {
        BulletController bulletController;

        public ParticleSystem BulletExplosion;

        public void SetBulletController(BulletController bc)
        {
            bulletController = bc;
        }

        private void Update()
        {
            FireBullet(transform.eulerAngles);
        }

        public void FireBullet(Vector3 tankRotation)
        {
            transform.eulerAngles = tankRotation;
            transform.position += transform.forward * bulletController.BulletModel.Speed * Time.deltaTime;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(!(collision.gameObject.GetComponent<IDamagable>() != null))
            {
                InstantiateShellExplosionParticleEffect();
            }
            bulletController.DestroyBullet();

        }

        private void InstantiateShellExplosionParticleEffect()
        {
            Instantiate(BulletExplosion, transform.position, new Quaternion(0f, 0f, 0f, 0f));
        }

        public void DestroyBulletPrefab()
        {
            Destroy(gameObject);
        }
    }
}