using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;                        // Used to filter what the explosion affects, this should be set to "Players".
    public ParticleSystem m_ExplosionParticles;         // Reference to the particles that will play on explosion.
    public float m_MaxDamage = 100f;                    // The amount of damage done if the explosion is centred on a tank.
    public float m_ExplosionForce = 1000f;              // The amount of force added to a tank at the centre of the explosion.
    //public float m_MaxLifeTime = 2f;                  // The time in seconds before the shell is removed.
    public float m_ExplosionRadius = 5f;                // The maximum distance away from the explosion tanks can be and are still affected.

    private  ParticleHolder particleHolder;

// ```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
// ```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````


    private void OnTriggerEnter (Collider other)
    {
        
        Collider[] colliders = Physics.OverlapSphere (transform.position, m_ExplosionRadius, m_TankMask);

       
        for (int i = 0; i < colliders.Length; i++)
        {
           
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody> ();     // find their rigidbody.

            if (!targetRigidbody)                                                   // If they don't have a rigidbody, go on to the next collider.
                continue;

            
            targetRigidbody.AddExplosionForce (m_ExplosionForce, transform.position, m_ExplosionRadius);        // Add an explosion force.
            // Find the TankHealth script associated with the rigidbody.
            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth> ();
            // If there is no TankHealth script attached to the gameobject, go on to the next collider.
            if (!targetHealth)
                continue;
            // Calculate the amount of damage the target should take based on it's distance from the shell.
            float damage = CalculateDamage (targetRigidbody.position);
            targetHealth.TakeDamage(damage);
        }
 
        m_ExplosionParticles.transform.parent = null;                                   // Unparent the particles from the shell.
        m_ExplosionParticles.Play();                                                    // Play the particle system.
        Destroy (m_ExplosionParticles.gameObject, m_ExplosionParticles.duration);

        gameObject.SetActive(false);                                                    // Deactivate the shell


    }


    private float CalculateDamage (Vector3 targetPosition)
    {
        
        Vector3 explosionToTarget = targetPosition - transform.position;                        // Create a vector from the shell to the target.
        float explosionDistance = explosionToTarget.magnitude;                                  // Calculate the distance from the shell to the target.
        float relativeDistance = (m_ExplosionRadius - explosionDistance)                        // Calculate the proportion of the maximum distance 
                                 / m_ExplosionRadius;                                                   
        float damage = relativeDistance * m_MaxDamage;                                          // Calculate damage in ratio to maximum possible damage.

        damage = Mathf.Max (0f, damage);                                                        // Make sure that the minimum damage is always 0 not -ve.
        return damage;
    }
}