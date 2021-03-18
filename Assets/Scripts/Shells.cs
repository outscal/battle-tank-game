using UnityEngine;
using System.Collections;

public class Shells : MonoBehaviour
{
    public LayerMask m_TankMask;                        // Used to filter what the explosion affects, this should be set to "Players".
    public float m_MaxDamage = 100f;                    // The amount of damage done if the explosion is centred on a tank.
    public float m_ExplosionForce = 1000f;              // The amount of force added to a tank at the centre of the explosion.
    public float m_MaxLifeTime = 2f;                    // The time in seconds before the shell is removed.
    public float m_ExplosionRadius = 3f;                // The maximum distance away from the explosion tanks can be and are still affected.

    public GameObject explosionInstance;
    public GameObject shellGo;

    IEnumerator DestroyExplosion(GameObject go)
    {
        yield return new WaitForSeconds(1f);
        PoolManager.Destroy(go);
    }
    private void Start()
    {
        PoolManager.SetNetPoolSize(explosionInstance, 10);
        PoolManager.SetPoolSize(explosionInstance, 5);

    }

    private void OnEnable()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (!(other.gameObject.tag == "Indestructible") || !(other.gameObject.tag == "Ground"))
        //if (other.gameObject.tag == "Untagged")
        {
            var explosionGo = PoolManager.Instantiate(explosionInstance, transform.position, transform.rotation);

            Collider[] collidersHit = Physics.OverlapSphere(transform.position, m_ExplosionRadius);

            foreach (Collider collider in collidersHit)
            {
                Rigidbody targetBody = collider.GetComponent<Rigidbody>();

                if (targetBody == null) { continue; }
                targetBody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

                explosionGo.GetComponent<ParticleSystem>().Play();
                explosionGo.GetComponent<AudioSource>().Play();
                StartCoroutine(DestroyExplosion(explosionGo));
            }

            PoolManager.GetPool(shellGo);
            PoolManager.Destroy(shellGo);
        }


    }

}
