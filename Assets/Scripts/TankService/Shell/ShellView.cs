using UnityEngine;

namespace TankBattle.Tank.Bullets
{
    [RequireComponent(typeof(Rigidbody))]
    public class ShellView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosionParticles;

        private AudioSource explosionAudio;
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            explosionAudio = GetComponent<AudioSource>();
        }

        private void Start()
        {

        }

        public Rigidbody GetRigidbody()
        {
            return rb;
        }

        public AudioSource GetAudioSystem()
        {
            return explosionAudio;
        }

        public ParticleSystem GetParticleSystem()
        {
            Debug.Log(explosionParticles);
            return explosionParticles;
        }
    }
}