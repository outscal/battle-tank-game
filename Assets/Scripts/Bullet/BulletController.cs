
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class BulletController
    {
        public BulletController(BulletModel bulletModel, BulletView bulletPrefab, Transform bulletParent)
        {
            C_BulletModel = bulletModel;
            C_BulletParent = bulletParent;
            C_BulletView = GameObject.Instantiate<BulletView>
                (bulletPrefab, bulletModel.SpawnTransform.position, bulletModel.SpawnTransform.rotation);
            C_BulletView.Initialize(this);
        }

        public BulletModel C_BulletModel { get; private set; }
        public BulletView C_BulletView { get; private set; }
        public Transform C_BulletParent { get; private set; }


        public BulletModel GetModel()
        {
            return C_BulletModel;
        }


        public void FireBullet(Transform bulletTransform, float bulletLaunchForce)
        {
            C_BulletView.bulletBody.velocity = bulletLaunchForce * bulletTransform.forward;
        }

        public void KillBullet()
        {
            Object.Destroy(C_BulletView.gameObject);
            C_BulletModel = null;
            C_BulletView = null;
            C_BulletParent = null;
        }

        public float CalculateDamage(Vector3 targetPosition, Vector3 bulletPosition, 
                                        float m_ExplosionRadius, float m_MaxDamage)
        {
            Vector3 explosionToTarget = targetPosition - bulletPosition;

            float explosionDistance = explosionToTarget.magnitude;

            float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

            float damage = relativeDistance * m_MaxDamage;

            damage = Mathf.Max(0f, damage);

            return damage;
        }
    }
}
