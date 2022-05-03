using System;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;
    public ParticleSystem m_ExplosionParticles;
    public float m_MaxDamage = 100f;
    public float m_ExplosionForce = 1000f;
    public float m_MaxLifeTime = 2f;
    public float m_ExplosionRadius = 5f;


    public void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }

    [Obsolete]
    public void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

            EnemyTankView targetHealth = targetRigidbody.GetComponent<EnemyTankView>();

            if (!targetHealth)
                continue;

            float damage = CalculateDamage(targetRigidbody.position);
            //targetHealth.TakeDamage(damage);

            IDamagable damagable = colliders[i].GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(damage);
                //damagable.TakeDamage(BulletModel.damage, BulletModel.Type);
            }
        }

        m_ExplosionParticles.transform.parent = null;
        m_ExplosionParticles.Play();
        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.duration);
        Destroy(gameObject);
    }


    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;
        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;
        float damage = relativeDistance * m_MaxDamage;
        damage = Mathf.Max(0f, damage);
        return damage;
    }
}
