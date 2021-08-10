using UnityEngine;


public class ShellExplosion : MonoBehaviour
{
    public ParticleSystem m_ExplosionParticles;
    public AudioSource m_ExplosionAudio;
    public float m_MaxLifeTime = 1f;

    private void Start()
    {


        // If it isn't destroyed by then, destroy the shell after it's lifetime.
        Destroy(gameObject, m_MaxLifeTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);

        }
        m_ExplosionParticles.transform.parent = null;

        m_ExplosionParticles.Play();

        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);
        Destroy(gameObject);

    }
}