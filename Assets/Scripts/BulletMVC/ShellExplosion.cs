using System;
using UnityEngine;

public class ShellExplosion : MonoBehaviour
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
            else if (targetRigidbody.GetComponent<ETankView>())
            {
                ETankView targetHealth = targetRigidbody.GetComponent<ETankView>();
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