using UnityEngine;

public class ShellExplotion : MonoBehaviour
{
    [SerializeField] LayerMask m_TankMask;
    [SerializeField] ParticleSystem m_ExplosionParticles;
    [SerializeField] float m_MaxDamage = 100f;
    [SerializeField] float m_ExplosionForce = 1000f;
    [SerializeField] float m_MaxLifeTime = 2f;
    [SerializeField] float m_ExplosionRadius = 5f;


    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

            HealthSlider targetHealth = targetRigidbody.GetComponent<HealthSlider>();

            if (!targetHealth)
                continue;

            float damage = CalculateDamage(targetRigidbody.position);

            targetHealth.TakeDamage(damage);
        }

        // Unparent the particles from the shell.
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
