using System;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    public LayerMask tankMask;
    public ParticleSystem explosionParticles;
    public float maxDamage = 100f;
    public float explosionForce = 1000f;
    public float maxLifeTime = 2f;
    public float explosionRadius = 5f;

    [Obsolete]
    public void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, tankMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].attachedRigidbody.GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

            if (targetRigidbody.GetComponent<TankView>())
            {
                TankView targetHealth = targetRigidbody.GetComponent<TankView>();
                if (!targetHealth)
                {
                    continue;
                }
                float damage = CalculateDamage(targetRigidbody.position);
                TakeDamage(damage, targetRigidbody);
            }
            else if (targetRigidbody.GetComponent<EnemyTankView>())
            {
                EnemyTankView targetHealth = targetRigidbody.GetComponent<EnemyTankView>();
                if (!targetHealth)
                {
                    continue;
                }
                float damage = CalculateDamage(targetRigidbody.position);
                TakeDamage(damage, targetRigidbody);
            }
        }
        explosionParticles.transform.parent = null;
        explosionParticles.Play();
        Destroy(explosionParticles.gameObject, explosionParticles.duration);
        Destroy(gameObject);
    }

    private void TakeDamage(float damage, Rigidbody targetRigidbody)
    {
        IDamagable damagable = targetRigidbody.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.TakeDamage(damage);
        }
    }
    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;
        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (explosionRadius - explosionDistance) / explosionRadius;
        float damage = relativeDistance * maxDamage;
        damage = Mathf.Max(0f, damage);
        return damage;
    }
}

//Reference Script for future

/* 

    bullet_sParent = transform.parent.gameObject.transform.parent.gameObject.transform;
    TankView go = bullet_sParent.gameObject.GetComponent<TankView>();

    if (bullet_sParent.gameObject.GetComponent<TankView>() == bullet_sParent.gameObject.GetComponent<TankView>())
    {
        Debug.Log("Bullet Founded Parent " + transform.parent.gameObject.transform.parent.gameObject.name);
        Debug.Log("Bullet Founded Parent " + bullet_sParent.gameObject.name);
    }

    Debug.Log("Bullet Not Found Parent " + bullet_sParent.gameObject.name);


    if (colliders[i].attachedRigidbody.GetComponent<TankView>())

    else if (colliders[i].attachedRigidbody.GetComponent<EnemyTankView>())
 
    IDamagable damagable = targetRigidbody.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.TakeDamage(damage);
            //damagable.TakeDamage(BulletModel.damage, BulletModel.Type);
        }
 
 */