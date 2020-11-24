using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;                        // Used to filter what the explosion affects,layer should be set to "Players".
    public float m_MaxDamage = 100f;                    // The amount of damage done if the explosion is centred on a tank.
    public float m_ExplosionForce = 100f;               // ShockWave force if tank at center of explosion
    public float m_MaxLifeTime = 2f;                    // The time in seconds before the shell is disabled.
    public float m_ExplosionRadius = 5f;                // The maximum distance away from the explosion tanks can be and are still affected.

// ```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
// ```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private void OnTriggerEnter (Collider other)
    {

        Collider[] collider = Physics.OverlapSphere (transform.position, m_ExplosionRadius);
        
        for (int i = 0; i < collider.Length; i++){

            IDamagable damagableObject = collider[i].GetComponent<IDamagable> ();
            Rigidbody targetRigidbody = collider[i].GetComponent<Rigidbody>();
            
            if(targetRigidbody!=null){

                targetRigidbody.AddExplosionForce (m_ExplosionForce, transform.position, m_ExplosionRadius);

            }

            if(damagableObject!=null){
            
                float damage = CalculateDamage (targetRigidbody.position);
                damagableObject.TakeDamage(damage);
            }
        }

        gameObject.SetActive(false);                                                    // Deactivate the shell

    }

// ```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
// ```````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

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