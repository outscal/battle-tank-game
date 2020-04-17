using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class BulletConroller
    {
        public BulletConroller(BulletModel bulletModel, BulletView bulletPrefab, Transform bulletParent)
        {
            BulletModel = bulletModel;
            BulletParent = bulletParent;
            BulletView = GameObject.Instantiate<BulletView>
                (bulletPrefab, bulletModel.SpawnTransform.position, bulletModel.SpawnTransform.rotation);
            BulletView.Initialize(this);
        }

        public BulletModel BulletModel { get; }
        public Transform BulletParent { get; }
        public BulletView BulletView { get; }


        public BulletModel GetModel()
        {
            return BulletModel;
        }


        public void FireBullet(Transform bulletTransform)
        {
            BulletView.bulletBody.velocity = BulletView.m_LaunchForce * bulletTransform.forward;
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
